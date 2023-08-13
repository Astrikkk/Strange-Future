using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryScript : MonoBehaviour
{
    public List<InventoryItem> RequiredItems;
    private Inventory inventory;
    public bool HaveBlueprint;
    private MassageBox MB;

    private void Start()
    {
        MB = GameObject.FindAnyObjectByType<MassageBox>();
        inventory = GameObject.FindAnyObjectByType<Inventory>();
    }

    public void PlaceAllItems()
    {
        if (HaveBlueprint)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                for (int j = 0; j < RequiredItems.Count; j++)
                {
                    InventoryItem requiredItem = RequiredItems[j];

                    if (inventory.HasItem(requiredItem))
                    {
                        inventory.RemoveItem(requiredItem);
                        RemoveRequiredItem(requiredItem);
                    }
                }
            }
        }
        else
        {
            MB.SendMessage("You dont have a blueprint !");
        }
    }
    public void RemoveRequiredItem(InventoryItem item)
    {
        if (RequiredItems.Contains(item))
        {
            RequiredItems.Remove(item);
        }
    }

}
