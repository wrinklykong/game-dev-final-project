using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO itemObject;
    public Sprite spriteObject;

    public void updateImage() {
        Button[] itemButton = GetComponentsInChildren<Button>();
        if ( itemButton[0] ) {
            itemButton[0].image.enabled = true;
            itemButton[0].image.color = new Color(1,1,1,1);
            itemButton[0].image.sprite = spriteObject;
        }
        else {
            Debug.Log("ERROR: No Image found in Child class");
        }
    }

    public void blankImage() {
        Button[] itemButton = GetComponentsInChildren<Button>();
        if ( itemButton[0] ) {
            itemButton[0].image.enabled = false;
        }
        else {
            Debug.Log("ERROR: No image found in Child class");
        }
    }

    public void resetImage() {
        Button[] itemButton = GetComponentsInChildren<Button>();
        if ( itemButton[0] ) {
            itemButton[0].image.sprite = null;
            itemButton[0].image.enabled = true;
        }
        else {
            Debug.Log("ERROR: No image found in Child class");
        }
    }

    public void showImage() {
        Button[] itemButton = GetComponentsInChildren<Button>();
        if ( itemButton[0] ) {
            itemButton[0].image.enabled = true;
        }
        else {
            Debug.Log("ERROR: No image found in Child class");
        }
    }
}
