using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject infoMenu;
    public GameObject buttons;

    bool info = false;
    void Start()
    {

    }

    void Update()
    {
        if(info && Input.GetButtonDown("Fire1"))
        {
            Back();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Info()
    {
        info = true;
        infoMenu.SetActive(true);
        buttons.SetActive(false);
    }

    public void Back()
    {
        info = false;
        infoMenu.SetActive(false);
        buttons.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}

public class MainButtons : MonoBehaviour, ISelectHandler
{
    public Button playButton;
    public Button infoButton;
    public Button exitButton;

    public void OnSelect(BaseEventData eventData)
    {
        
    }
}
