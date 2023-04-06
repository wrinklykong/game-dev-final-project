using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioScript : MonoBehaviour
{

    [Header("Audio Clips")]
    public AudioClip pullUpInventory;
    public AudioClip pullDownInventory;
    public AudioClip doorSFX;
    public AudioClip itemSFX;

    public AudioClip errorSFX;

    private AudioSource sfxSource;

    void Start() {
        sfxSource = GetComponent<AudioSource>();
    }

    public void playClip(string sfxname, string args) {
        AudioClip clipToBePlayed;
        switch( sfxname ) {
            case "pullUpInventory":
                clipToBePlayed = pullUpInventory;
                break;
            case "pullDownInventory":
                clipToBePlayed = pullDownInventory;
                break;
            case "door":
                clipToBePlayed = doorSFX;
                break;
            case "item":
                clipToBePlayed = itemSFX;
                break;
            default:
                clipToBePlayed = errorSFX;
                break;
        }
        sfxSource.PlayOneShot(clipToBePlayed);
    }
}
