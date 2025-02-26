using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishingTrigger : MonoBehaviour
{
    public GameObject minigame;


    [SerializeField] private GameplaySettings gpSettings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            Destroy(other.gameObject);
            transform.position = transform.parent.transform.position;
            gameObject.SetActive(false);
            gpSettings.fishBitesLine();
        }
    }
}