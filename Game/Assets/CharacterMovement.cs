using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb2d;
    public bool talkingToNPC;

    [Header("Scriptable Objects")]
    public ItemSO newItem;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rb2d = GetComponent<Rigidbody2D>();
        talkingToNPC = false;
    }

    public void startTalkingToNPC() {
        talkingToNPC = true;
        rb2d.velocity = new Vector2(0, 0);
    }

    public void stopTalkingToNPC() {
        talkingToNPC = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( !talkingToNPC ) {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            rb2d.velocity = new Vector2(speed * moveHorizontal, speed * moveVertical);
        }

    }
}
