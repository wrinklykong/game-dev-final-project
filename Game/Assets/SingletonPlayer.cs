using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonPlayer : Singleton
{
    public static Singleton player { get; private set; }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if ( player != null && player != this ) {
            Destroy(this);
        }
        else {
            player = this;
        }
    }
}
