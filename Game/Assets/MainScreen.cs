using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    public void startGame() {
        Debug.Log("Clicked start game!");
        SceneManager.LoadScene("LoadThingsScene", LoadSceneMode.Single);
    }

}
