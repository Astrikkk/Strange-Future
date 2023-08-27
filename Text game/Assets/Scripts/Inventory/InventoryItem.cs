using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ItemsType { Water, Food, Ticket, Gun, Instrument, BluePrint }

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public List<string> name;
    public List<string> description;
    public Sprite icon;
    public ItemsType itemsType;
    public int AddFood;
    public int AddWater;
}
