using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    private bool pause;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject quitMenuUI;
    [SerializeField] private GameObject controlsMenuUI;

    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    public void Quitmenu()
    {
        PauseMenuUI.SetActive(false);
        quitMenuUI.SetActive(true);
        pause = true;
    }

    public void Controls()
    {
        Debug.Log("controls");
    }

    public void QuitToTitle()
    {
        Debug.Log("title screen");
    }

    public void Back()
    {
        PauseMenuUI.SetActive(true);
        quitMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
