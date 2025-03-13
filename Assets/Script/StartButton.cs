using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StartButton : MonoBehaviour
{

    private Devices Device = Devices.Keyboard;
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDevice();

        switch (Device)
        {
            case Devices.Keyboard:
                tmp.text = "press enter to continue...";
                break;
            case Devices.Gamepad:
                tmp.text = "press button to continue...";
                break;
        }
    }

    private void OnEnterGame()
    {
        Debug.Log("Entering");
        StartCoroutine(loadNextScene());
    }

    IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(1);
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);
    }


    void CheckDevice()
    {
        if (Input.anyKey)
        {
            Device = Devices.Keyboard;
        }

        if (Input.GetJoystickNames().Length > 0)
        {
            foreach (string joystickName in Input.GetJoystickNames())
            {
                if (!string.IsNullOrEmpty(joystickName))
                {
                    Device = Devices.Gamepad;
                }
            }
        }
    }

    public enum Devices
    {
        Keyboard,
        Gamepad
    }
}
