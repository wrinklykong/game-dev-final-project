using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScriptTitle : MonoBehaviour
{
    private Slider[] sliders;
    private Canvas cv;

    public AudioMixer mixer;
    public SFXAudioScriptTitle audios;
    public AudioSource audioss;

    public AudioSource audiom;

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
        Text[] allTexts = this.GetComponentsInChildren<Text>();
        foreach ( Text a in allTexts ) {
            Debug.Log(a.color.a);
            a.color = new Color(1,1,1,1);
        }
    }

}
