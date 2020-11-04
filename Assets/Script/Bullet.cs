using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    protected Myscript owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = FindObjectOfType<Myscript>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        owner.AddScore();
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
