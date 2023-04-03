using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO itemObject;
    public Sprite spriteObject;

    public void updateImage() {
        Image[] itemImg = GetComponentsInChildren<Image>();
        if ( itemImg[1] ) {
            itemImg[1].color = new Color(0,0,0,1);
            itemImg[1].sprite = spriteObject;
        }
        else {
            Debug.Log("ERROR: No Image found in Child class");
        }
    }
}
