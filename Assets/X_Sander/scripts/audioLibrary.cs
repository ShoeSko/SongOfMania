using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLibrary : MonoBehaviour
{
    public List<AudioClip> audioclips;
    int wanjangle;
    AudioSource audioSource;
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }
    public void playAduio(string who, int emotion)
    {
        AudioClip clip;

        if (who == "???" || who == "Orpheus")
        {
            wanjangle = 4;
        }
        else
        {
            wanjangle = 0;
        }
        audioSource.Stop();
        switch (emotion)
        {
            case 1:
                clip = audioclips[0 + wanjangle];
                audioSource.clip = clip;
                audioSource.Play();
                break;
            case 2:
                clip = audioclips[1 + wanjangle];
                audioSource.clip = clip;
                audioSource.Play();
                break;
            case 3:
                clip = audioclips[2 + wanjangle];
                audioSource.clip = clip;
                audioSource.Play();
                break;
            case 4:
                clip = audioclips[3 + wanjangle];
                audioSource.clip = clip;
                audioSource.Play();
                break;
            default:
                print("null");
                break;

        }

        string findSound = who + emotion;


    }
}
