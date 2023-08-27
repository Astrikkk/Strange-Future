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
    private Timer timer;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        Wm = FindObjectOfType<WaitManager>();
        MB = FindObjectOfType<MassageBox>();
        timer = FindObjectOfType<Timer>();
    }

    public void Swim()
    {
        MB.CannotSwimMessage();
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
            MB.NoFishingRodMessage();
        }
    }
}
