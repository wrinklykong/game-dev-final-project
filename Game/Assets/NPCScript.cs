using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public NPCSO npcObject;
    private SpriteRenderer so;
    private string nameOfNPC;
    private string[] dialogueList;

    // Start is called before the first frame update
    void Start()
    {
        so = GetComponent<SpriteRenderer>();
        nameOfNPC = npcObject.npcName;
        dialogueList = npcObject.dialogue;
        so.sprite = npcObject.npcSprite;
    }

    public string getName() {
        return nameOfNPC;
    }

    public string[] getDialogueList() {
        return dialogueList;
    }
}
