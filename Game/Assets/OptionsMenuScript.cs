using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider MasterSlider;
    public Slider otherSlider;

    public AudioMixer mixer;

    void Start() {
        this.enabled = true;
    }


    void SetVolume(string groupName, int value) {
        Debug.Log("not implemented");
    }

}
