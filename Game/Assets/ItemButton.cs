using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public Transform inventoryPanel;
    public Transform buttonTransform;
    public float fadeInTime = 0.5f;

    public void onInventoryExpandClick() {
        ShowInventory();
    }

    public void onInventoryDepressClick() {
        Debug.Log("Help me!");
        HideInventory();
    }

    public IEnumerator ShowInventory() {
        // enable the image

        StartCoroutine(ShowInventoryRoutine());
        IEnumerator ShowInventoryRoutine(){
            Vector3 ogInventory = inventoryPanel.position;
            Vector3 ogButton = transform.position;
            Vector3 otherButton = buttonTransform.position;

            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                inventoryPanel.position = ogInventory + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
                transform.position = ogButton - new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
                buttonTransform.position = otherButton + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
            }
        }
        return null;
    }

    public IEnumerator HideInventory() {
        // enable the image

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