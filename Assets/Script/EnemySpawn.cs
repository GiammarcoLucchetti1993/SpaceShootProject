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

    public bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(EnemyShoot());
        shoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenBounds.x -5)
        {
            Debug.Log(screenBounds.x);
            Destroy(this.gameObject);
        }
        if(shoot == true && transform.position.x < screenBounds.x - 0.25f)
        {
            ShootBullet();
            //time = 0;
            shoot = false;
        }
        if(transform.position.x < screenBounds.x - 3f)
        {
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        //if (transform.position.x < screenBounds.x -0.25f)
        //{
            GameObject b = Instantiate(bulletEnemyPrefab) as GameObject;
            b.transform.position = new Vector2(this.transform.position.x - 0.4f, this.transform.position.y);
        //}
    }

    //IEnumerator EnemyShoot()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(timeToShoot);
    //        ShootBullet();
    //    }

    //}

}
