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

    private GameObject option1;
    private GameObject option2;

    private Button option1button;
    private Button option2button;
    private Image option1image;
    private Image option2image;
    private Text option1text;
    private Text option2text;

    public CharacterMovement cm;

    void Start()
    {
        DialogueList = new Queue();
        DialogueBox = GetComponentInChildren<Text>();
        DialogueContainerImage = GetComponentInChildren<Image>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        option1 = GameObject.FindGameObjectsWithTag("option1")[0];
        option2 = GameObject.FindGameObjectsWithTag("option2")[0];
        option1button = option1.GetComponentInChildren<Button>();
        option2button = option2.GetComponentInChildren<Button>();

        option1image = option1.GetComponentInChildren<Image>();
        option2image = option2.GetComponentInChildren<Image>();

        option1text = option1.GetComponentInChildren<Text>();
        option2text = option2.GetComponentInChildren<Text>();
    }

    public void hideOptions() {
        option1button.enabled = false;
        option2button.enabled = false;
        option1image.enabled = false;
        option2image.enabled = false;
        option1text.enabled = false;
        option2text.enabled = false;
    }

    private void showOptions() {
        option1button.enabled = true;
        option2button.enabled = true;
        option1image.enabled = true;
        option2image.enabled = true;
        option1text.enabled = true;
        option2text.enabled = true;
    }

    private void destroyDialogueQueue() {
        DialogueList = new Queue();
    }

    public void initializeDialogue( string[] a ) {
        destroyDialogueQueue();
        foreach ( string x in a ) {
            DialogueList.Enqueue(x);
        }
        nextDialogue();
    }

    public void nextDialogue() {
        Debug.Log("Hello");
        try {
            string nextD = (string)DialogueList.Dequeue();
            if ( nextD == "OPTION" ) {
                // option1.SetActive(true);
                // option2.SetActive(true);
                //string option1String = (string)DialogueList.Dequeue();
                //string option2String = (string)DialogueList.Dequeue();
                //string[] option1split = option1String.Split(char.Parse(","));
                //string[] option2split = option2String.Split(char.Parse(","));
                option1text.text = (string)DialogueList.Dequeue();
                //opt1Pos = int.Parse(option1split[1]);
                option2text.text = (string)DialogueList.Dequeue();
                //opt2Pos = int.Parse(option2split[1]);
                nextD = (string)DialogueList.Dequeue();
                updateBox(nextD);
                cm.startTalkingToNPC();
                inventoryCanvas.enabled = false;
                showOptions();
            }
            else if ( nextD == "END" ) {
                updateBox("NULL");
                hideBox();
                cm.stopTalkingToNPC();
                inventoryCanvas.enabled = true;
                return;
            }
            else {
                updateBox(nextD);
                cm.startTalkingToNPC();
                inventoryCanvas.enabled = false;
            }
        }
        catch (Exception e) {
            //Debug.Log(e);
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
        Canvas[] allCanvases = inventoryCanvas.GetComponentsInChildren<Canvas>();
        foreach ( Canvas a in allCanvases ) {
            a.enabled = false;
        }
    }
    void hideBox() {
        canvas.enabled = false;
        Canvas[] allCanvases = inventoryCanvas.GetComponentsInChildren<Canvas>();
        foreach ( Canvas a in allCanvases ) {
            a.enabled = true;
        }
    }

    public void OptionClicked(int option) {
        // option = 1 or 2
        string optType = (option==1) ? "OPT1" : "OPT2";
        // go until option 1
        hideOptions();
        string nextD = (string)DialogueList.Dequeue();
        try {
            while ( nextD != optType ) {
                nextD = (string)DialogueList.Dequeue();
            }
            nextD = (string)DialogueList.Dequeue();
            updateBox(nextD);
            cm.startTalkingToNPC();
            inventoryCanvas.enabled = false;
        }
        catch (Exception e) {
            Debug.Log(e);
            updateBox("NULL");
            hideBox();
            cm.stopTalkingToNPC();
            inventoryCanvas.enabled = true;
        }
    }



}
