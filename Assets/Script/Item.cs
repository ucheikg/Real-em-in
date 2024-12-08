using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] private Image _image; public Image GetImage() {  return _image; }

    [SerializeField] private string ItemName = string.Empty; public string GetItemName() {  return ItemName; }

    [SerializeField] private Vector2 minMaxWeight = new Vector2(0f,1f); public Vector2 GetMinMaxWeight() { return minMaxWeight; }

    [SerializeField] private float weight = 0.0f; public float GetWeight() { return weight; }

    [SerializeField] private Rarity rarity = Rarity.Common; public Rarity GetRarity() { return rarity; }

    [SerializeField] private float Chance = 0.0f; public float GetChance() { return Chance; }

    private float miniGameDifficulty = 0f; public float GetMiniGameDifficulty() { return miniGameDifficulty; }
    private float healthDrainDifficulty = 0f; public float GetHealthDrainDifficulty() { return healthDrainDifficulty; }

    public void onLine()
    {
        weight = Random.Range(minMaxWeight.x, minMaxWeight.y);

        miniGameDifficulty = minMaxWeight.y / weight;
        
        switch (rarity)
        {
            case Rarity.Common:
                healthDrainDifficulty = 0f;
                break;
            case Rarity.Uncommon:
                healthDrainDifficulty = 0f;
                break;
            case Rarity.Rare:
                healthDrainDifficulty = 0f;
                break;
            case Rarity.Epic:
                healthDrainDifficulty = 10f;
                break;
            case Rarity.Legendary:
                healthDrainDifficulty = 40f;
                break;
            case Rarity.Mythical:
                healthDrainDifficulty = 60f;
                break;
        }
    }
}

public enum Rarity
{
    Common = 0,
    Uncommon = 1,
    Rare = 2,
    Epic = 3,
    Legendary = 4,
    Mythical = 5
}
