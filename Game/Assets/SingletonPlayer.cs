using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonPlayer : MonoBehaviour
{
    public static SingletonPlayer instance { get; private set; }
    private Transform playerTransform;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if ( instance ) {
            Destroy(this);
        }
        else {
            instance = this;
        }
        playerTransform = instance.GetComponentsInChildren<Transform>()[1];
    }

    public void changePos( float xPos, float yPos) {
        //Debug.Log("Changed pos; x: "+ xPos +" y: "+ yPos);
        Vector3 old = playerTransform.position;
        //Debug.Log("old: x: "+old.x+" y: "+old.y);
        old.x = xPos;
        old.y = yPos;
        playerTransform.position = old;
    }
}
