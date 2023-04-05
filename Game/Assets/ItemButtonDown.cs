using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonDown : MonoBehaviour
{

    Transform inventoryPanel;
    public Transform openButton;
    public float fadeInTime = 0.5f;

    public void Start() {
        inventoryPanel = GetComponentInParent<Transform>();
    }

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
            Vector3 ogButton = openButton.position;

            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                inventoryPanel.position = ogInventory + new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
                transform.position = ogButton - new Vector3(0, Mathf.Lerp(0,4,timer/fadeInTime) ,0);
            }
        }
        return null;
    }

    public IEnumerator HideInventory() {
        // enable the image

        StartCoroutine(HideInventoryRoutine());
        IEnumerator HideInventoryRoutine(){
            Vector3 ogInventory = inventoryPanel.position;
            Vector3 ogButton = openButton.position;

            float timer = 0;
            while ( timer<fadeInTime){
                yield return null;
                timer+=Time.deltaTime;
                inventoryPanel.position = ogInventory - new Vector3(0, Mathf.Lerp(4,0,timer/fadeInTime) ,0);
                transform.position = ogButton + new Vector3(0, Mathf.Lerp(4,0,timer/fadeInTime) ,0);
            }
        }
        return null;
    }

}
