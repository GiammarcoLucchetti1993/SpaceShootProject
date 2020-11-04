using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject canvasAnimation;

    public float transitionTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        canvasAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartApplication()
    {
        //LoadLevel(SceneManager.LoadScene("StartGame"));
        canvasAnimation.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("StartGame");
    }

}
