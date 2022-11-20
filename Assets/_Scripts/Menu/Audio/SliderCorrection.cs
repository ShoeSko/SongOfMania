using UnityEngine;
using UnityEngine.UI;

public class SliderCorrection : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider VocalSlider;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        VocalSlider.value = PlayerPrefs.GetFloat("VocalVolume");
    }
}
