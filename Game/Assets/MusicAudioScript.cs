using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioScript : MonoBehaviour
{

    [Header("Audio Clips")]
    public AudioClip testSong;
    public AudioClip test;

    public AudioClip errorSFX;
    public AudioClip sampleSceneAS;
    public AudioClip citySceneAS;
    public AudioClip cemetarySceneAS;
    public AudioClip houseSceneAS;
    public AudioClip graveSceneAS;


    public AudioSource musicSource;

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
                clipToBePlayed = test;
                break;
            case "sampleScene":
                clipToBePlayed = sampleSceneAS;
                break;
            case "cemetaryScene":
                clipToBePlayed = cemetarySceneAS;
                break;
            case "houseScene":
                clipToBePlayed = houseSceneAS;
                break;
            case "graveScene":
                clipToBePlayed = graveSceneAS;
                break;
            case "cityScene":
                clipToBePlayed = citySceneAS;
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
