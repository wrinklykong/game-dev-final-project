using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorCollider : MonoBehaviour
{

    public Image transition;
    void OnTriggerEnter2D(Collider2D collision) {

        if ( collision.CompareTag("door")) {
            Debug.Log("Touching door!");
            SceneManager.LoadScene("HouseScene", LoadSceneMode.Single);
        }
    }
}
