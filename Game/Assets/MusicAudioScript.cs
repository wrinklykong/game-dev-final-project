using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioScript : Singleton
{

    [Header("Audio Clips")]
    public AudioClip testSong;

    public AudioClip errorSFX;

    private AudioSource musicSource;

    public static Singleton music { get; private set; }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if ( music != null && music != this ) {
            Destroy(this);
        }
        else {
            music = this;
        }
    }

    public void playClip(string musicname, string args) {
        AudioClip clipToBePlayed;
        switch( musicname ) {
            case "test":
                clipToBePlayed = testSong;
                break;
            default:
                clipToBePlayed = errorSFX;
                break;
        }
        musicSource.clip = clipToBePlayed;
        musicSource.Play();
    }
}
