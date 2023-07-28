using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class InventoriesManager : MonoBehaviour
{
    public List<Box> boxes;
    public Inventory playerInventory;
    public int currentBox = 0;
    public int currentItemIndex = 0;


    private void FixedUpdate()
    {
        boxes[currentBox].ShowIcon();
        playerInventory.currentBox = boxes[currentBox];
    }

    public void ChangeCurrentItem(int index)
    {
        if (index >= 0 && index < boxes[currentBox].items.Count)
        {
            currentItemIndex = index;
        }
    }


    public void SaveAllInventoriesToJson()
    {
        SavePlayerInventoryToJson();
        SaveBoxesToJson();
    }
    public void LoadAllInventoriesFromJson()
    {
        LoadPlayerInventoryFromJson();
        LoadBoxesFromJson();
    }
    public void SaveBoxesToJson()
    {
        foreach (var box in boxes)
        {
            box.SaveInventoryToJson();
        }
    }
    public void LoadBoxesFromJson()
    {
        foreach (var box in boxes)
        {
            box.LoadInventoryFromJson();
        }
    }
    public void SavePlayerInventoryToJson()
    {
        playerInventory.SaveInventoryToJson();
    }
    public void LoadPlayerInventoryFromJson()
    {
        playerInventory.LoadInventoryFromJson();
    }
}
