using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeScene()
    {
        //SceneManager.LoadScene(sceneIndex);
        print("Changed scene");
    }

    public void MoveCam()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeScene();
        }
    }
}
