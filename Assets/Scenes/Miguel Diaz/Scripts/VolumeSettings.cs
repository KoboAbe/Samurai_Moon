using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

//------------------------------------------------------------------------------------------------------
    public void SetMusicVolume(){
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", volume);   
    }

    public void SetSFXVolume(){
        float volume = musicSlider.value;
        audioMixer.SetFloat("SFX", volume);   
    }

//------------------------------------------------------------------------------------------------------


//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------

}
