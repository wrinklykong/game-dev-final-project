using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    private Slider[] sliders;
    private Canvas cv;

    public AudioMixer mixer;
    public SFXAudioScript audios;
    public AudioSource audioss;

    void Start() {
        this.enabled = true;
        sliders = GetComponentsInChildren<Slider>();
        cv = GetComponent<Canvas>();
    }


    void SetVolume(string groupName, float value) {
        float volume = Mathf.Log10(value) * 20;
        if ( value == 0 ) {
            volume = -80;
        }
        mixer.SetFloat(groupName, volume);
    }

    public void setSFXVolume() {
        SetVolume("SFX", sliders[0].value);
        if ( !audioss.isPlaying ) {
            audios.playClip("item","o");
        } 
    }

    public void setMusicVolume() {
        SetVolume("Music", sliders[1].value);
    }

    public void setMasterVolume() {
        SetVolume("Master", sliders[2].value);
    }

    public void closeMenu() {
        cv.enabled = false;
    }

    public void openMenu() {
        cv.enabled = true;
    }

}
