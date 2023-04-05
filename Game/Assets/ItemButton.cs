using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public Transform inventoryPanel;
    public Transform buttonTransform;
    public Transform cameraPos;
    public SFXAudioScript sfxSource;

    public float fadeInTime = 0.2f;

    public void onInventoryExpandClick() {
        ShowInventory();
    }

    public void onInventoryDepressClick() {
        Debug.Log("Help me!");
        HideInventory();
    }

    public IEnumerator ShowInventory() {
        // enable the image

        sfxSource.playClip("pullUpInventory", "o");
        StartCoroutine(ShowInventoryRoutine());
        IEnumerator ShowInventoryRoutine(){
            Vector3 ogInventory = inventoryPanel.position;
            Vector3 ogButton = transform.position;
            Vector3 otherButton = buttonTransform.position;
            Vector3 ogCamera = cameraPos.position;
            Vector3 deltaCamera;


            float timer = 0;
            while ( timer<fadeInTime){
                deltaCamera = ogCamera-cameraPos.position;

                yield return null;
                timer+=Time.deltaTime;
                inventoryPanel.position  = ogInventory + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0) - deltaCamera;
                transform.position = ogButton - new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0) - deltaCamera;
                buttonTransform.position = otherButton + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0) - deltaCamera;
            }
        }
        return null;
    }

    public IEnumerator HideInventory() {
        // enable the image

        sfxSource.playClip("pullDownInventory", "o");
        StartCoroutine(HideInventoryRoutine());
        IEnumerator HideInventoryRoutine(){
            Vector3 ogInventory = inventoryPanel.position;
            Vector3 ogButton = transform.position;
            Vector3 otherButton = buttonTransform.position;

            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                inventoryPanel.position = ogInventory - new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
                transform.position = ogButton + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
                buttonTransform.position = otherButton - new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
            }
        }
        return null;
    }

}
