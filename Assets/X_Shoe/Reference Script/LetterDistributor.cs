using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LetterDistributor : MonoBehaviour
{
    [SerializeField] private List<string> _keywords = new List<string>(); //A list of all keywords

    [SerializeField] private List<string> _passwords = new List<string>(); //A list of all passwords

    [SerializeField] private List<string> _passwordsChecker = new List<string>(); //A list of all passwords

    private List<string> _charactersList = new List<string>();

    [SerializeField] private TextMeshProUGUI _stringWall;

    [SerializeField] private TextMeshProUGUI _keywordField;

    private float waitTime = 0.05f;

    [SerializeField] private GameObject eventsystem;

    private string currentWrittenCharacter;
    private int randomCharacterValue;
    private int amountOfStringsOnWall = 800;
    private int passwordToUse1;
    private int passwordToUse2;
    private int passwordToUse3;
    private int passwordToUse4;

    private int currentAnswerInt;
    [SerializeField] private TMP_InputField _passwordAnswered;

    [SerializeField] List<GameObject> keywordSecionList = new List<GameObject>();
    [SerializeField] List<GameObject> WinLoseObjects = new List<GameObject>();

    private bool gameStart;
    [SerializeField] private GameObject pressAnyKey;

    private void Start()
    {
        _charactersList = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " ", "-" }; //28 strings
        for (int i = 0; i < keywordSecionList.Count; i++)
        {
            keywordSecionList[i].SetActive(false);
            WinLoseObjects[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(!gameStart && Input.anyKey)
        {
            gameStart = true;
            pressAnyKey.SetActive(false);
            GenerateTheStringWall();
        }
    }

    [ContextMenu("Write Code")]
    public void GenerateTheStringWall()
    {
        StopAllCoroutines();
        currentWrittenCharacter = "";

        PickThePasswords();

        StartCoroutine(SlowDownWritingSpeed());
    }

    private void PickThePasswords()
    {
        passwordToUse1 = Random.Range(0, _passwords.Count);
        passwordToUse2 = Random.Range(0, _passwords.Count);
        passwordToUse3 = Random.Range(0, _passwords.Count);
        passwordToUse4 = Random.Range(0, _passwords.Count);

        while (passwordToUse2 == passwordToUse1)
        {
            passwordToUse2 = Random.Range(0, _passwords.Count);
        }
        while (passwordToUse3 == passwordToUse2)
        {
            passwordToUse3 = Random.Range(0, _passwords.Count);
        }
        while (passwordToUse4 == passwordToUse3)
        {
            passwordToUse4 = Random.Range(0, _passwords.Count);
        }
    }

    IEnumerator SlowDownWritingSpeed()
    {
        int firstPassword = Random.Range(50, 150);
        int secondPassword = Random.Range(200, 350);
        int thirdPassword = Random.Range(400, 550);
        int fourthPassword = Random.Range(600, 750);
        for (int i = 0; i < amountOfStringsOnWall; i++)
        {
            if(i == firstPassword)
            {
                string[] _wordCharactersList = _passwords[passwordToUse1].Split(char.Parse(","));
                for (int id = 0; id < _wordCharactersList.Length; id++)
                {
                    yield return new WaitForSeconds(waitTime);
                    currentWrittenCharacter = currentWrittenCharacter + _wordCharactersList[id]; //Add word splitt
                    _stringWall.text = currentWrittenCharacter;
                }
                yield return null;
            }
            else if(i == secondPassword)
            {
                string[] _wordCharactersList = _passwords[passwordToUse2].Split(char.Parse(","));
                for (int id = 0; id < _wordCharactersList.Length; id++)
                {
                    yield return new WaitForSeconds(waitTime);
                    currentWrittenCharacter = currentWrittenCharacter + _wordCharactersList[id]; //Add word splitt
                    _stringWall.text = currentWrittenCharacter;
                }
                yield return null;
            }
            else if(i == thirdPassword)
            {
                string[] _wordCharactersList = _passwords[passwordToUse3].Split(char.Parse(","));
                for (int id = 0; id < _wordCharactersList.Length; id++)
                {
                    yield return new WaitForSeconds(waitTime);
                    currentWrittenCharacter = currentWrittenCharacter + _wordCharactersList[id]; //Add word splitt
                    _stringWall.text = currentWrittenCharacter;
                }
                yield return null;
            }
            else if(i == fourthPassword)
            {
                string[] _wordCharactersList = _passwords[passwordToUse4].Split(char.Parse(","));
                for (int id = 0; id < _wordCharactersList.Length; id++)
                {
                    yield return new WaitForSeconds(waitTime);
                    currentWrittenCharacter = currentWrittenCharacter + _wordCharactersList[id]; //Add word splitt
                    _stringWall.text = currentWrittenCharacter;
                }
                yield return null;
            }
            else //Writes random ass code!!!
            {
                yield return new WaitForSeconds(waitTime);
                randomCharacterValue = Random.Range(0, _charactersList.Count);
                currentWrittenCharacter = currentWrittenCharacter + _charactersList[randomCharacterValue];
                _stringWall.text = currentWrittenCharacter;
            }
        }
        ShowKeyword();
        yield return null;
    }

    private void ShowKeyword()
    {
        int chosenPassword = Random.Range(0, 4);
        for (int i = 0; i < keywordSecionList.Count; i++)
        {
            keywordSecionList[i].SetActive(true);
        }
        eventsystem.SetActive(false);
        eventsystem.SetActive(true);

        if(chosenPassword == 0)
        {
            _keywordField.text = _keywords[passwordToUse1];
            currentAnswerInt = passwordToUse1;
        }
        else if (chosenPassword == 1)
        {
            _keywordField.text = _keywords[passwordToUse2];
            currentAnswerInt = passwordToUse2;
        }
        else if (chosenPassword == 2)
        {
            _keywordField.text = _keywords[passwordToUse3];
            currentAnswerInt = passwordToUse3;
        }
        else if (chosenPassword == 3)
        {
            _keywordField.text = _keywords[passwordToUse4];
            currentAnswerInt = passwordToUse4;
        }
    }

    public void CheckPassword()
    {
        if (_passwordAnswered.text.ToLower() == _passwordsChecker[currentAnswerInt].ToLower())
        {
            _stringWall.text = "";
            for (int i = 0; i < keywordSecionList.Count; i++)
            {
                keywordSecionList[i].SetActive(false);
            }

            WinLoseObjects[0].SetActive(true);
            WinLoseObjects[1].SetActive(true);
        }
        else 
        {
            _stringWall.text = "";
            for (int i = 0; i < keywordSecionList.Count; i++)
            {
                keywordSecionList[i].SetActive(false);
            }

            WinLoseObjects[0].SetActive(true);
            WinLoseObjects[2].SetActive(true);
        }
    }

    public void ResetFunction()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            UnityEditor.EditorApplication.isPlaying = false; //Quits game, both in build and editor.
        }
#else
        Application.Quit();
#endif
    }
}
