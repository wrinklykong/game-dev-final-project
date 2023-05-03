using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=9yFnaLD0PLI&ab_channel=THSSTech
public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public SFXAudioScript sfxAS;

    private Rigidbody2D rb2d;
    private bool talkingToNPC;
    private SpriteRenderer sr;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rb2d = GetComponent<Rigidbody2D>();
        talkingToNPC = false;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
            if ( moveHorizontal == 0 ) {
                anim.Play("Idle");
            }
            else {
                if ( moveHorizontal < 0 ) {
                    sr.flipX = true;
                }
                else {
                    sr.flipX = false;
                }
                if ( !anim.GetCurrentAnimatorStateInfo(0).IsName("Walking") ) {
                    anim.Play("Walking");
                }
                else if (!sfxAS.sfxSource.isPlaying) {
                    SFXAudioScript.instance.playClip("walk", "o");
                }
            }
        }

    }
}
