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
    
    public ItemSO itemGivenToPlayer;    // makes my life easier :)

    private bool itemGiven = false;

    public bool handleItemGiven( int item ) {
        if ( item == itemNeeded ) {
            // load in the reactionToItemGiven string to the dialogue box
            DialogueScript.instance.initializeDialogue( reactionToItemGiven );
            itemGiven = true;
            return true;
        }
        else {
            /// load in the unknwon item given into the dialogue box
            DialogueScript.instance.initializeDialogue( unknownItemGiven );
            return false;
        }
    }

    public string[] getDialogueForBox() {
        return itemGiven ? dialogueAfterItemGiven : dialogue;       // dunno if works lol
    }
    
}
