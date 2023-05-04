using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-activeSceneChanged.html

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance { get; private set; }
    public string lastScene;
    public MusicAudioScript aScript;

    public AudioClip sampleSceneAS;

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
            
                aScript.playClip("houseScene", "o");
                SingletonPlayer.instance.changePos(0.3f,0.2f);
                break;
            case "SampleScene":
                aScript.playClip("sampleScene", "o");
                if ( lastScene == "HouseScene" ) {
                    SingletonPlayer.instance.changePos(3.7f,7.5f);
                }
                else if ( lastScene == "CityScene" ) {
                    SingletonPlayer.instance.changePos(14f,9.25f); // need to change
                }
                break;
            case "CityScene":
                aScript.playClip("cityScene", "o");
                if ( lastScene == "CemetaryScene" ) {
                    SingletonPlayer.instance.changePos(16f,13.5f);  // for some reason, need to add like +3 on Y for it to proplery work, idk why
                }
                else if ( lastScene == "SampleScene" ) {
                    SingletonPlayer.instance.changePos(-3.5f,2f);
                }
                else if ( lastScene == "HousePrefab" ) {
                    SingletonPlayer.instance.changePos(6.9f,11.6f);
                }
                break;
            case "HousePrefab":
                aScript.playClip("houseScene", "o");
                SingletonPlayer.instance.changePos(4.15f,-2.5f);  // for some reason, need to add like +3 on Y for it to proplery work, idk why
                break;
            case "CemetaryScene":
                aScript.playClip("cemetaryScene", "o");
                SingletonPlayer.instance.changePos(3f, 0f);
                break;
            case "GraveScene":
                aScript.playClip("graveScene", "o");
                SingletonPlayer.instance.changePos(-1.5f, 1.5f);
                break;
            default:
                break;
        }
        lastScene = next.name;
        TransitionImage.instance.FadeIn();
    }
}
