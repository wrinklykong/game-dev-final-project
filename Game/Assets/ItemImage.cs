using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImage : MonoBehaviour
{
    public Sprite imageSprite;

    public void updateImage() {
        GetComponent<Image>().sprite = imageSprite;
    }
}
