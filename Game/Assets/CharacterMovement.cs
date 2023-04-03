using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb2d;

    [Header("Scriptable Objects")]
    public ItemSO newItem;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        rb2d.velocity = new Vector2(speed * moveHorizontal, speed * moveVertical);

    }
}
