using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D ccollider;

    public Rigidbody2D rg;

    private float width;

    private float scrollSpeed = -1f;


    // Start is called before the first frame update
    void Start()
    {
        ccollider = GetComponent<BoxCollider2D>();
        rg = GetComponent<Rigidbody2D>();

        width = ccollider.size.x;
        ccollider.enabled = false;

        rg.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
