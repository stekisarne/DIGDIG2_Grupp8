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

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Play()
    {

    }

    public void Info()
    {
        
    }

    public void Back()
    {

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
