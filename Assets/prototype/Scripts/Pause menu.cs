using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class Pausemenu : MonoBehaviour
{
    private bool pause;
    [SerializeField] private GameObject PauseMenuUI;


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
    public void Quit()
    {
        Debug.Log("quit");
    }

    public void Controls()
    {
        Debug.Log("controls");
    }

}
