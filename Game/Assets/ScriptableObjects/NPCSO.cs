using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Examples/DefaultNPC")]

public class NPCSO : ScriptableObject
{
    public string npcName;
    public string[] dialogue;           // Initial dialogue that comes up
    public Sprite npcSprite;
    public int itemNeeded;
    public string[] reactionToItemGiven;
    public string[] dialogueAfterItemGiven;
    public string[] unknownItemGiven;
    public string[] disgusedReaction;
    
    public ItemSO itemGivenToPlayer;    // makes my life easier :)

    private bool itemGiven = false;

    public bool handleItemGiven( int item ) {
        Debug.Log("ItemNeeded: "+itemNeeded);
        if ( item == itemNeeded ) {
            // load in the reactionToItemGiven string to the dialogue box
            DialogueScript.instance.initializeDialogue( reactionToItemGiven, itemGivenToPlayer );
            itemGiven = true;
            if ( npcName == "CemDoor" ) {
                CemetaryManager.instance.deleteDoor();
            }
            else if ( npcName == "GraveToBeDug" ) {
                Debug.Log("Digging grave");
                CemetaryManager.instance.digGrave();
            }
            return true;
        }
        else {
            /// load in the unknwon item given into the dialogue box
            DialogueScript.instance.initializeDialogue( unknownItemGiven, itemGivenToPlayer );
            return false;
        }
    }

    public string[] getDialogueForBox() {
        if ( itemGiven ) {
            return dialogueAfterItemGiven;
        }
        else if ( SingletonPlayer.instance.isDisgused() && npcName == "Guard" && !itemGiven ) {          // change the thingy LOL ^_^
            return disgusedReaction;
        }
        return dialogue;
    }

    public ItemSO getItemToGiveSO() {
        Debug.Log(itemGivenToPlayer);
        return itemGivenToPlayer;
    }
    
}
