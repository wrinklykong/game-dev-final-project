using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-activeSceneChanged.html

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance { get; private set; }
    public string lastScene;

    void Awake() {
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        lastScene = "";
    }
    void Start() {
        TransitionImage.instance.FadeIn();
        //SingletonPlayer.instance.changePos(0,0);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void onDisable() {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next) {
        string currentName = current.name;

        if ( currentName == null ) {
            currentName = "replaced";
        }
        //Debug.Log("Scenes: " + currentName + ", " + next.name);
        // are nested switch statements a good idea? maybe not lol
        switch (next.name) {
            case "HouseScene":
                SingletonPlayer.instance.changePos(0.3f,0.2f);
                break;
            case "SampleScene":
                if ( lastScene == "HouseScene" ) {
                    SingletonPlayer.instance.changePos(3.7f,7.5f);
                }
                else if ( lastScene == "CityScene" ) {
                    SingletonPlayer.instance.changePos(14.5f,7.25f); // need to change
                }
                break;
            case "CityScene":
                if ( lastScene == "CemetaryScene" ) {
                    SingletonPlayer.instance.changePos(16f,13.5f);  // for some reason, need to add like +3 on Y for it to proplery work, idk why
                }
                else if ( lastScene == "SampleScene" ) {
                    SingletonPlayer.instance.changePos(-3.5f,2f);
                }
                break;
            case "CemetaryScene":
                SingletonPlayer.instance.changePos(3f, 0f);
                break;
            default:
                break;
        }
        lastScene = next.name;
        TransitionImage.instance.FadeIn();
    }
}
