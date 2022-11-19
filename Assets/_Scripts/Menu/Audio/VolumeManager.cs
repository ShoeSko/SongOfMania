using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [Header("Mixers")]
    public AudioMixer masterMixer;

    //Missing feature. Upon loading sliders, they are not set to correct value

    private void Awake()
    {
        //If first time setup, store Values at halfpoint
        if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            //Record that first time has been run once
            PlayerPrefs.SetInt("FirstTime", 1);

            //Store the value of the floats
            PlayerPrefs.SetFloat("MasterVolume", 1f); //Value to be changed
            PlayerPrefs.SetFloat("MusicVolume", 1f); //Value to be changed
            PlayerPrefs.SetFloat("SFXVolume", 1f); //Value to be changed

            //Save new settings
            PlayerPrefs.Save();
        }
        //Update Mixers to be correct (Has to be done everytime)
        SetMixersReady();
    }

    private void SetMixersReady()
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20);
    }

    public void SetMasterVolume(float sliderValue)
    {
        //Adjust volume in a logarithmic scale.
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void SetMusicVolume(float sliderValue)
    {
        //Adjust volume in a logarithmic scale.
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        //Adjust volume in a logarithmic scale.
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

}
