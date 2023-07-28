using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Craftable Item", menuName = "Crafting/Craftable Item")]
public class CraftableItem : ScriptableObject
{
    public new string name;
    public List<InventoryItem> Item;
    public List<int> DisappearingItems;
    public InventoryItem[] requiredItems;
}
