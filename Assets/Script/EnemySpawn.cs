using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject bulletEnemyPrefab;

    public float timeToShoot = 3f;

    public float timeShoot = 2f;
    public float time;

    private float objectWidth;
    private float objectHeight;

    public bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectWidth = transform.GetComponent<Collider2D>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<Collider2D>().bounds.size.y / 2;
        shoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x - objectWidth)
        {
            Destroy(this.gameObject);
        }
        if (shoot == true && transform.position.x < screenBounds.x - objectWidth)
        {
            ShootBullet();
            //time = 0;
            shoot = false;
        }
    }

    public void ShootBullet()
    {
        GameObject b = Instantiate(bulletEnemyPrefab) as GameObject;
        b.transform.position = new Vector2(this.transform.position.x - objectWidth * 2, this.transform.position.y);
    }
}
