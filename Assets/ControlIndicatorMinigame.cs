using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ControlIndicatorMinigame : MonoBehaviour
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
                tmp.text = "SPACE!";
                break;
            case Devices.Gamepad:
                tmp.text = "REEL!";
                break;
        }
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
