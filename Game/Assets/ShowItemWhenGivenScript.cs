using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemWhenGivenScript : MonoBehaviour
{

    public Transform topSpinny;
    public Transform bottomSpinny;
    public Transform itemTransform;

    public SpriteRenderer topSr;
    public SpriteRenderer bottomSr;
    public SpriteRenderer itemSr;

    
    public static ShowItemWhenGivenScript instance { get; private set; }

    private void Awake() {
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void showItemWhenGiven(ItemSO item) {
        
        StartCoroutine(SpinnyCORoutine());

        IEnumerator SpinnyCORoutine() {
            float timer = 0;
            itemSr.sprite = item.img;
            topSr.enabled = true;
            bottomSr.enabled = true;
            itemSr.enabled = true;

            while ( timer < 3.0f ){
                yield return null;
                topSpinny.Rotate(0,0,0.5f);
                bottomSpinny.Rotate(0,0,-0.5f);
                timer+=Time.deltaTime;
                if ( timer < 0.5f ) {
                    float lerpedvalue = Mathf.Lerp(0, 1, timer/0.5f);
                    topSpinny.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                    bottomSpinny.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                    itemTransform.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                }
                else if (timer > 2.5f ){
                    float lerpedvalue = Mathf.Lerp(1, 0, (timer-2.5f)/0.5f);
                    topSpinny.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                    bottomSpinny.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                    itemTransform.localScale = new Vector3(lerpedvalue,lerpedvalue,lerpedvalue);
                }

            }
            topSr.enabled = false;
            bottomSr.enabled = false;
            itemSr.enabled = false;
        }
        return;
    }
}
