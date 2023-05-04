using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemetaryManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public CapsuleCollider2D cc;
    
    public BoxCollider2D doorToGrave;
    public CircleCollider2D digGraveCollider;

    public static CemetaryManager instance { get; private set; }

    private void Awake() {
        instance = this;
    }

    public void deleteDoor() {
        sr.enabled = false;
        cc.enabled = false;
    }

    public void digGrave() {
        doorToGrave.enabled = false;
        digGraveCollider.enabled = true;
    }
}
