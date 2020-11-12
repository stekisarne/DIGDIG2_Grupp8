using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex; //Scene number in build settings

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeScene() //changes scene to sceneIndex
    {
        //SceneManager.LoadScene(sceneIndex);
        print("Changed scene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeScene();
        }
    }
}
