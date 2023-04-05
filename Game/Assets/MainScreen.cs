using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void startGame() {
        Debug.Log("Clicked start game!");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void options() {
        Debug.Log("Clicked options!");
    }
}
