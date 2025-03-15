using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{

    private void OnReplayGame()
    {
        SceneManager.LoadScene(0);
    }
}
