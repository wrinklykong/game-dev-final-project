using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTriggers : MonoBehaviour
{

    public InventorySO inventory;
    public InventoryPanel panel;
    public TransitionImage transition;
    private Image alertImage;
    private bool touchingNPC;
    public DialogueScript dialogueContainer;
    private Collider2D currentCollision;

    public void Start() {
        alertImage = GetComponentInChildren<Image>();
        touchingNPC = false;
    }

    public void Update() {
        if ( touchingNPC && Input.GetKeyDown("space") ) {
            // Debug.Log("Touching NPC and Spacebar pressed");
            dialogueContainer.initializeDialogue(currentCollision.gameObject.GetComponent<NPCScript>().getDialogueList());
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if ( other.tag == "item" ) {
            // Debug.Log("Item touched!");
            ItemSO itemTouched = other.gameObject.GetComponent<Container>().item;
            Debug.Log(itemTouched);
            if (itemTouched) {
                if ( inventory.addItem(itemTouched) != -1 ) {
                    panel.updateInventory();
                    Destroy(other.gameObject);
                }
                else {
                    // message above item that says your inventory is full
                }
            }
            else {
                Debug.Log("ERROR: NO item found :,(");
            }
        }
        else if ( other.CompareTag("door")) {
            // Debug.Log("Touching door!");
            transition.FadeOut();
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