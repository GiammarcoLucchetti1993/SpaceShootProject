using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectWidth = EnemyPrefab.transform.GetComponent<Collider2D>().bounds.size.x / 2;
        objectHeight = EnemyPrefab.transform.GetComponent<Collider2D>().bounds.size.y / 2;
        StartCoroutine(EnemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(EnemyPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + objectHeight, screenBounds.y - objectHeight));
    }

    IEnumerator EnemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
        
    }

}
