using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioScriptTitle : MonoBehaviour
{

    [Header("Audio Clips")]
    public AudioClip testSong;
    public AudioClip test;

    public AudioClip errorSFX;
    public AudioClip sampleSceneAS;

    public AudioSource musicSource;

    void Start() {
        playClip("sampleScene", "o");
    }

    public void playClip(string musicname, string args) {
        AudioClip clipToBePlayed;
        switch( musicname ) {
            case "test":
                clipToBePlayed = test;
                break;
            case "sampleScene":
                clipToBePlayed = sampleSceneAS;
                break;
            default:
                clipToBePlayed = errorSFX;
                break;
        }
        musicSource.clip = clipToBePlayed;
        musicSource.Play();
    }


    public void stopMusic() {
        musicSource.Stop();
    }
}
