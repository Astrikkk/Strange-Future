using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public InventoryItem FishingRod;
    public InventoryItem fish;
    private Inventory inventory;
    private WaitManager Wm;
    private MassageBox MB;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Wm = FindFirstObjectByType<WaitManager>();
        MB = FindFirstObjectByType<MassageBox>();
    }



    public void Swim()
    {
        MB.SendMessage("You cant swim here, its too dangerous");
    }

    public void Fish()
    {
        if (inventory.HasItem(FishingRod))
        {
            int RandomNumber = Random.Range(0, 4);
            if (inventory.CanFitItemsInInventory(1))
            {
                for (int i = 0; i < RandomNumber; i++)
                {
                    inventory.AddObj(fish);
                }
            }
        }
        else
        {
            MB.SendMessage("You dont have a fishing row");
        }
    }
}
