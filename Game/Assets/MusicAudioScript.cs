using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioScript : Singleton
{

    [Header("Audio Clips")]
    public AudioClip testSong;

    public AudioClip errorSFX;

    private AudioSource musicSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        musicSource = GetComponent<AudioSource>();
        playClip("test", "o");
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
