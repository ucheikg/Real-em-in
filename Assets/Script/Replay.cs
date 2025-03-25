using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    GameSettings gameSettings;

    private void OnReplayGame()
    {
        SceneManager.LoadScene(0);
        gameSettings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
        gameSettings.SetPlayerCurrentScore(0);
    }
}
