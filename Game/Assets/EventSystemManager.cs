using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager instance { get; private set; }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
}
