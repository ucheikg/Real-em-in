using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;
using static UnityEngine.Rendering.DebugUI.Table;

public class GameplaySettings : MonoBehaviour
{
    private GameSettings gameSettings;
    [SerializeField] private Fish_Marker fishMarker;
    [SerializeField] private rodScript rod;
    [SerializeField] private GameObject miniGame;


    [SerializeField] private Item fish; // Fish that has bit the line.
    public Item getFish() { return fish;  }
    public void setFish(Item f) { fish = f; }
    [Space(5)]


    [SerializeField] private List<Item> fishPool = new List<Item>();    // All fish that can be caught. 
    public List<Item> getFishPool() { return fishPool; }
    public void addFishToPool(Item f) { fishPool.Add(f); }


    



    private void Start()
    {
        miniGame.SetActive(false);
        gameSettings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
    }

    public void fishBitesLine()
    {
        int fishNum = Random.Range(0, 1000);

        SortPoolByChance();

        List<int> fishRarityList = new List<int>();
        foreach (Item item in fishPool)
        {
            fishRarityList.Add(int.Parse((item.GetChance() * 10).ToString()));
        }

        for(int i = 0; i < fishPool.Count; i++)
        {
            if (fishRarityList[i] <= fishNum)
            {
                continue;
            }
            else
            {
                fish = fishPool[i];
                break;
            }
        }

        miniGame.SetActive(true);
        fishMarker.canMove = true;
        rod.canCharge = false;
        fishMarker.startMarker();
        fish.onLine();

        Debug.Log("Minigame Start!");
    }

    public void clearFishCaught() // clears fish
    {
        fish = null;
    }

    private void SortPoolByChance() // sort fish by chance
    {
        fishPool.Sort((a, b) => { return a.GetChance().CompareTo(b.GetChance()); });
    }

    public void addScoreToPlayer()
    {
        int currentScore = gameSettings.GetPlayerCurrentScore();
        int fishScore = fish.GetScore();

        gameSettings.SetPlayerCurrentScore(currentScore + fishScore);
    }

}
