using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioScript : Singleton
{

    [Header("Audio Clips")]
    public AudioClip pullUpInventory;
    public AudioClip pullDownInventory;
    public AudioClip doorSFX;
    public AudioClip itemSFX;
    public AudioClip pickUp;
    public AudioClip setDown;
    public AudioClip badClick;
    public AudioClip eat;

    public AudioClip errorSFX;

    private AudioSource sfxSource;

    public static Singleton sfx { get; private set; }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if ( sfx != null && sfx != this ) {
            Destroy(this);
        }
        else {
            sfx = this;
        }
    }

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
            case "pickUp":
                clipToBePlayed = pickUp;
                break;
            case "setDown":
                clipToBePlayed = setDown;
                break;
            case "badClick":
                clipToBePlayed = badClick;
                break;
            case "eat":
                clipToBePlayed = eat;
                break;
            default:
                clipToBePlayed = errorSFX;
                break;
        }
        sfxSource.PlayOneShot(clipToBePlayed);
    }

}
