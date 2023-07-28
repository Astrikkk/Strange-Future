using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public List<CraftableItem> items;
    public Inventory inventory;

    public List<Image> slots;


    private void FixedUpdate()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            bool canCraft = CheckIFCanCraft(items[i]);
            Image slotImage = slots[i].GetComponent<Image>();
            slotImage.color = canCraft ? Color.white : Color.black;
        }
    }

    public void Craft(CraftableItem item)
    {
        if (inventory.CanFitItemsInInventory(item.Item.Count))
        {
            for (int i = 0; i < item.Item.Count; i++)
            {
                inventory.AddObj(item.Item[i]);
            }
            foreach (int index in item.DisappearingItems)
            {
                if (index >= 0 && index < item.requiredItems.Length)
                {
                    InventoryItem itemToRemove = item.requiredItems[index];
                    inventory.RemoveItem(itemToRemove);
                }
            }
        }
    }


    public bool CheckIFCanCraft(CraftableItem craftableItem)
    {
        bool canCraft = true;

        foreach (InventoryItem requiredItem in craftableItem.requiredItems)
        {
            if (!inventory.HasItem(requiredItem))
            {
                canCraft = false;
                break;
            }
        }

        return canCraft;
    }




}
