using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Myscript : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton joybutton;

    private Vector2 screenBounds;

    protected bool fire;

    private float objectWidth;
    private float objectHeight;

    public GameObject bulletPrefab;

    public int Score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectWidth = transform.GetComponent<Collider2D>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<Collider2D>().bounds.size.y /2;
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(joystick.Horizontal * 1f, joystick.Vertical * 1f);

        if(!fire && joybutton.Pressed)
        {
            fire = true;
        }

        if (fire && !joybutton.Pressed)
        {
            fire = false;
            ShootBullet();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "EnemyBullet")
        {
            SceneManager.LoadScene("GameOver");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth , screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight , screenBounds.y - objectHeight);
        transform.position = viewPos;
    }


    public void ShootBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = new Vector2(this.transform.position.x + objectWidth, this.transform.position.y);
    }

    public void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

}
