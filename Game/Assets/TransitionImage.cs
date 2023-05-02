using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionImage : MonoBehaviour
{
    Image img;
    public float fadeInTime = 2;
    // Start is called before the first frame update

    public static TransitionImage instance { get; private set; }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
        }
        img = GetComponent<Image>();
        //FadeIn();
    }

    public void FadeIn() {
        Debug.Log("Fading in...");
        // enable the image
        img.enabled = true;
        //img.color = new Color(0,0,0,0);

        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine(){
            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                img.color = new Color(0,0,0,Mathf.Lerp(1, 0, timer/fadeInTime));
                //Debug.Log("im fadoooing omg...");
            }
        }
        return;
    }

    public void FadeOut(string scene) {
        // enable the image
        
        Debug.Log("Fading out...");
        img.enabled = true;
        StartCoroutine(FadeOutRoutine());
        IEnumerator FadeOutRoutine(){
            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                img.color = new Color(0,0,0,Mathf.Lerp(0, 1, timer/fadeInTime));
            }
            switch (scene) {
                case "doorToShop":
                    SceneManager.LoadScene("HouseScene", LoadSceneMode.Single);
                    break;
                case "doorToCity":
                    SceneManager.LoadScene("CityScene", LoadSceneMode.Single);
                    break;
                case "doorToDock":
                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                    break;
                default:
                    Debug.Log("Unknown scene :,(");
                    break;
            }
        }
        return;
    }
}
