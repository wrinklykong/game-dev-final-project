using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCollider : MonoBehaviour
{

    public TransitionImage transition;

    void OnTriggerEnter2D(Collider2D collision) {

        if ( collision.CompareTag("door")) {
            Debug.Log("Touching door!");
            transition.FadeOut();
        }
    }
}
