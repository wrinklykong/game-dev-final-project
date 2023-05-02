using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioScript : Singleton
{

    [Header("Audio Clips")]
    public AudioClip testSong;

    public AudioClip errorSFX;

    private AudioSource musicSource;

    public static MusicAudioScript instance { get; private set; }

    private void Awake() {
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
