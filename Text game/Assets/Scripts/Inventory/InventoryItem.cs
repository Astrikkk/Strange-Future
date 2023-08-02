using UnityEngine;
using UnityEngine.UI;

public enum ItemsType { Water, Food, Ticket, Gun, Instrument }

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public ItemsType itemsType;
}
