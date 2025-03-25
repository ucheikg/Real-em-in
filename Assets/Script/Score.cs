using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    GameSettings gameSettings;
    
    void Start()
    {
        gameSettings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
        Score.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + gameSettings.GetPlayerCurrentScore().ToString();
    }
}
