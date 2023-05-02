using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-activeSceneChanged.html

public class GameManagerScript : MonoBehaviour
{

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        TransitionImage.instance.FadeIn();
        //SingletonPlayer.instance.changePos(0,0);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void onDisable() {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next) {
        Debug.Log("OnSceneLoaded: "+next.name);
        string currentName = current.name;

        if ( currentName == null ) {
            currentName = "replaced";
        }
        Debug.Log("Scenes: " + currentName + ", " + next.name);
        switch (next.name) {
            case "HouseScene":
                SingletonPlayer.instance.changePos(0.3f,0.2f);
                break;
            default:
                break;
        }
        TransitionImage.instance.FadeIn();
    }
}
