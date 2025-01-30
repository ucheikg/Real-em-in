using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;

public class GameSettings : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    private void Start()
    {

        if(PlayerPrefs.GetString("PlayerName") != null)
        {
            SetPlayerName(PlayerPrefs.GetString("PlayerName"));
        }

        string print = string.Empty;
        print = "Inventory Before";
        foreach(Item i in Inventory)
        {
            print = print+"\n"+i.GetItemName() + " : " + i.GetWeight().ToString() + " : " + i.GetRarity().ToString();
        }
        Debug.Log(print);

        SortInventoryByName();
        print = "Inventory After Sort By Name";
        foreach (Item i in Inventory)
        {
            print = print + "\n" + i.GetItemName() + " : " + i.GetWeight().ToString() + " : " + i.GetRarity().ToString();
        }
        Debug.Log(print);

        SortInventoryByWeight();
        print = "Inventory After Sort By Weight";
        foreach (Item i in Inventory)
        {
            print = print + "\n" + i.GetItemName() + " : " + i.GetWeight().ToString() + " : " + i.GetRarity().ToString();
        }
        Debug.Log(print);

        SortInventoryByRarity();
        print = "Inventory After Sort By Rarity";
        foreach (Item i in Inventory)
        {
            print = print + "\n" + i.GetItemName() + " : " + i.GetWeight().ToString() + " : " + i.GetRarity().ToString();
        }
        Debug.Log(print);
    }



    #region Player
    [Header("Player")]
    [SerializeField] private string playerName = string.Empty; public string GetPlayerName() { return playerName; }
                                                               public void SetPlayerName(string name) {  playerName = name; }

    [SerializeField] private float playerHighestWeightFish = 0.0f; public float GetPlayerHightWeightFish() { return playerHighestWeightFish; }
                                                                 public void SetPlayerHightWeightFish(float weight) { playerHighestWeightFish = weight; }
    #endregion


    #region Inventory

    [SerializeField] private List<Item> Inventory = new List<Item>();

    public void InventoryAddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void InventoryRemoveItem(Item item)
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i] == item)
            {
                Inventory.RemoveAt(i);
                return;
            }
        }
    }

    public void SortInventoryByWeight()
    {
        Inventory.Sort((a, b) => { return a.GetWeight().CompareTo(b.GetWeight()); });
    }

    public void SortInventoryByName()
    {
        Inventory.Sort((a, b) => { return a.GetItemName().CompareTo(b.GetItemName()); });
    }

    public void SortInventoryByRarity()
    {
        Inventory.Sort((a, b) => { return a.GetRarity().CompareTo(b.GetRarity()); });
    }

    #endregion
}
