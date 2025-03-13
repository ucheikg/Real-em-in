using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    GameSettings gameSettings;
    void Start()
    {
        gameSettings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Final Score: " + gameSettings.GetPlayerCurrentScore().ToString();
    }
}
