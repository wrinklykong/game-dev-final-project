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
    void Awake()
    {
        so = this.GetComponent<SpriteRenderer>();
        nameOfNPC = npcObject.npcName;
        dialogueList = npcObject.dialogue;
        so.sprite = npcObject.npcSprite;
    }

    public string getName() {
        return nameOfNPC;
    }

    public string[] getDialogueList() {
        return npcObject.getDialogueForBox();
    }

    public void testScript() {
        Debug.Log("Hello!");
    }

    public bool handleItemGiven(ItemSO itemGiven) {
        Debug.Log(npcObject.handleItemGiven(itemGiven.id));
        return npcObject.handleItemGiven(itemGiven.id);
    }

    public ItemSO getItemToGive() {
        return npcObject.getItemToGiveSO();
    }
}
