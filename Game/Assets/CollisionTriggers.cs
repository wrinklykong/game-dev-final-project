using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTriggers : MonoBehaviour
{

    public InventorySO inventory;
    public InventoryPanel panel;
    public TransitionImage transition;
    public DialogueScript dialogueContainer;
    public SFXAudioScript mixer;

    private Collider2D currentCollision;
    private bool touchingNPC;
    private Image alertImage;



    public void Start() {
        alertImage = GetComponentInChildren<Image>();
        touchingNPC = false;
    }

    public void Update() {
        if ( touchingNPC && Input.GetKeyDown("space") ) {
            // Debug.Log("Touching NPC and Spacebar pressed");
            dialogueContainer.initializeDialogue(currentCollision.gameObject.GetComponent<NPCScript>().getDialogueList(), currentCollision.gameObject.GetComponent<NPCScript>().getItemToGive());      // DISGUSTING!
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if ( other.tag == "item" ) {
            // Debug.Log("Item touched!");
            ItemSO itemTouched = other.gameObject.GetComponent<Container>().item;
            if (itemTouched) {
                if ( inventory.addItem(itemTouched) != -1 ) {
                    panel.updateInventory();
                    Destroy(other.gameObject);
                    SFXAudioScript.instance.playClip("item", "o");
                }
                else {
                    // message above item that says your inventory is full
                }
            }
            else {
                Debug.Log("ERROR: NO item found :,(");
            }
        }
        else if ( other.tag.Length > 3 && other.tag.Substring(0,4) == "door" ) {
            // Debug.Log("Touching door!");
            mixer.playClip("door", "o");
            transition.FadeOut(other.tag);       // more like, switch scenes
        }
        else if ( other.CompareTag("npc") ) {
            Debug.Log("Touching NPC!");
            alertImage.enabled = true;
            touchingNPC = true;
            currentCollision = other;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if ( other.tag == "npc" ) {
            touchingNPC = false;
            alertImage.enabled = false;
            currentCollision = null;
        }
    }

}