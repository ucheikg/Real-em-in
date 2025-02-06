using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingTrigger : MonoBehaviour
{
    public GameObject minigame;

    [SerializeField] private GameplaySettings gpSettings;
    void Start()
    {
        minigame.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            other.gameObject.SetActive(false);
            minigame.SetActive(true);
            gpSettings.fishBitesLine();
        }
    }
}