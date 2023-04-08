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

    void Start() {
        holdingItem = false;
        img = GetComponent<Image>();
        pos = GetComponent<Transform>();

        img.enabled = false;
    }

    void Update()
    {
        if ( holdingItem ) {
            Vector2 relativePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            pos.position = relativePosition;
            if ( Input.GetKeyDown("l") ) {
                releaseItem();
            }
        }
    }

    public void holdItem( Sprite s ) {
        Debug.Log("Holdign sprite now");
        img.enabled = true;
        if ( holdingItem ) {
            Debug.Log("Already holding item :,(");
        }
        else {
            holdingItem = true;
            img.sprite = s;
        }
    }

    public void releaseItem() {
        img.enabled = false;
        holdingItem = false;
    }
}
