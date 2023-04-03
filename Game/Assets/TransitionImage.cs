using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionImage : MonoBehaviour
{
    public Image img;
    public float fadeInTime = 1;
    // Start is called before the first frame update

    void Start()
    {
        FadeIn();
    }

    IEnumerator FadeIn() {
        // enable the image
        img.enabled = true;

        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine(){
            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                img.color = new Color(0,0,0,Mathf.Lerp(0, 1, timer/fadeInTime));
            }
        }
        yield return null;
    }

    public IEnumerator FadeOut() {
        // enable the image
        img.enabled = true;
        StartCoroutine(FadeOutRoutine());
        IEnumerator FadeOutRoutine(){
            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                img.color = new Color(0,0,0,Mathf.Lerp(1, 0, timer/fadeInTime));
            }
        }
        yield return null;
    }
}
