using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionHider : MonoBehaviour
{
    // Start is called before the first frame update

    public bool showCollision = false;

    private TilemapRenderer tmr;

    void Start()
    {
        tmr = GetComponent<TilemapRenderer>();
        tmr.enabled = showCollision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
