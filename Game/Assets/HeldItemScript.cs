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

    public InventorySO playerInventory;
    public SFXAudioScript sfxMixer;
    public InventoryPanel ip;

    void Start() {
        holdingItem = false;
        img = GetComponent<Image>();
        pos = GetComponent<Transform>();
        canUseItem = false;
        itemHeldDown = -1;

        img.enabled = false;
    }

    void Update()
    {
        if ( holdingItem ) {
            Vector2 relativePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            pos.position = relativePosition;
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
    }
}
