using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    private Queue DialogueList;
    private Text DialogueBox;
    private Image DialogueContainerImage;
    private Canvas canvas;
    public Canvas inventoryCanvas;

    public CharacterMovement cm;

    void Start()
    {
        DialogueList = new Queue();
        DialogueBox = GetComponentInChildren<Text>();
        DialogueContainerImage = GetComponentInChildren<Image>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        //updateBox("Hello!");
    }

    public void initializeDialogue( string[] a ) {
        foreach ( string x in a ) {
            DialogueList.Enqueue(x);
        }
        nextDialogue();
    }

    public void nextDialogue() {
        Debug.Log("Hello");
        try {
            string nextD = (string)DialogueList.Dequeue();
            updateBox(nextD);
            cm.startTalkingToNPC();
            inventoryCanvas.enabled = false;
        }
        catch (Exception e) {
            updateBox("NULL");
            hideBox();
            cm.stopTalkingToNPC();
            inventoryCanvas.enabled = true;
        }
    }

    void updateBox( string a ) {
        showBox();
        DialogueBox.text = a;
    }

    void showBox() {
        canvas.enabled = true;
    }
    void hideBox() {
        canvas.enabled = false;
    }



}