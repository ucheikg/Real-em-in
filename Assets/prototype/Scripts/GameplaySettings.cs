using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySettings : MonoBehaviour
{

    [SerializeField] private Item fish; // Fish that has bit the line.
    public Item getFish() { return fish;  }
    public void setFish(Item f) { fish = f; }
    [Space(5)]


    [SerializeField] private List<Item> fishPool = new List<Item>();    // All fish that can be caught. 
    public List<Item> getFishPool() { return fishPool; }
    public void addFishToPool(Item f) { fishPool.Add(f); }


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
            if (fishRarityList[i] > fishNum)
            {
                continue;
            }
            else
            {
                fish = fishPool[i];
                return;
            }
        }
    }

    public void clearFishCaught() // clears fish
    {
        fish = null;
    }

    private void SortPoolByChance() // sort fish by chance
    {
        fishPool.Sort((a, b) => { return a.GetChance().CompareTo(b.GetChance()); });
    }
}
