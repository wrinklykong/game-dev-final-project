using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public static FollowPlayerScript instance { get; private set; }

    private void Awake() {
        if ( instance != null && instance != this ) {
            Destroy(this);
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y+ offset.y, -10 );
    }
}
