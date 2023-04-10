using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItemScript : MonoBehaviour
{

    private Sprite heldItemSprite;
    private bool holdingItem;
    private Image img;
    private Transform pos;
    private float timeClicked;
    private bool canUseItem;
    private int itemHeldDown;
    private Transform childSpritePos;
    private SpriteRenderer childSpriteSpr;
    private Text itemActionText;

    public InventorySO playerInventory;
    public SFXAudioScript sfxMixer;
    public InventoryPanel ip;

    void Start() {
        holdingItem = false;
        img = GetComponent<Image>();
        pos = GetComponent<Transform>();
        childSpritePos = GetComponentsInChildren<Transform>()[1];
        childSpriteSpr = GetComponentsInChildren<SpriteRenderer>()[0];
        itemActionText = GetComponentsInChildren<Text>()[0];
        canUseItem = false;
        itemHeldDown = -1;

        img.enabled = false;
    }

    void Update()
    {
        if ( holdingItem ) {
            Vector2 relativePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            pos.position = relativePosition;
            childSpritePos.position = relativePosition + new Vector2(0,0.5f);
            itemActionText.transform.position = relativePosition + new Vector2(0.75f,0.2f);
            if ( !canUseItem && Time.time - timeClicked > 0.15 ) {
                canUseItem = true;
            }
            if ( Input.GetMouseButtonDown(0) && canUseItem ) {
                releaseItem();
            }
        }
    }

    public void holdItem( int itemNum ) {
        if ( itemNum >= 12 ) {       // size of inventory is 12
            Debug.Log("Bad access!");
            sfxMixer.playClip("badClick", "o");
            return;
        } 
        if ( holdingItem ) {
            Debug.Log("TODO: Swap held items");
        }
        else if ( playerInventory.objects[itemNum] ) {       // if item exists, grab it
            itemHeldDown = itemNum;
            img.enabled = true;
            holdingItem = true;
            img.sprite = playerInventory.objects[itemHeldDown].img;
            timeClicked = Time.time;
            sfxMixer.playClip("pickUp", "o");
            ip.itemsInventory[itemHeldDown].blankImage();
        }
        else {
            Debug.Log("No item found!");            
            sfxMixer.playClip("badClick", "o");
        }
    }

    public void releaseItem() {
        img.enabled = false;
        holdingItem = false;
        canUseItem = false;
        timeClicked = 0f;
        sfxMixer.playClip("setDown", "o");
        ip.itemsInventory[itemHeldDown].showImage();
        itemHeldDown = -1;
        childSpriteSpr.enabled = false;
        itemActionText.enabled = false;
    }

    public void handleOnPlayer() {
        // check if the item is edible, if not, DIE!
        // if ( ip.itemsInventory[itemHeldDown].edible ) {
        //     Debug.Log("Edible!");
        //     itemActionText.text = "Eat";
        // }
        // else {
        //     itemActionText.text = "Not edible!";
        // }
        itemActionText.text = "Eat!";
        childSpriteSpr.enabled = true;
        itemActionText.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        switch (other.tag) 
        {
            case "player":
                Debug.Log("Eat this item!");
                handleOnPlayer();
                break;
            case "npc":
                Debug.Log("NPC!");
                break;
            default:
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        childSpriteSpr.enabled = false;
        itemActionText.enabled = false;
    }

}
