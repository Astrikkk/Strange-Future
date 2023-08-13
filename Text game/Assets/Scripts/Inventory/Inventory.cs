using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;
    public int Capacity;
    public Image[] slots;
    public Box currentBox;
    public int currentItemIndex = 0;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public InventoriesManager IO;
    public Sprite SlotIcon;
    private WaitManager WM;
    private MassageBox MB;



    private void Start()
    {
        WM = GameObject.FindAnyObjectByType<WaitManager>();
        MB = GameObject.FindAnyObjectByType<MassageBox>();
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].sprite = items[i].icon;
            else slots[i].sprite = SlotIcon;
        }
    }
    public void AddObj(InventoryItem item)
    {
        if (items.Count < Capacity)
        {
            items.Add(item);
            slots[items.Count - 1].sprite = item.icon;
        }
    }
    public void RemoveItem(InventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }
    public void RemoveObj()
    {
        if (currentItemIndex >= 0 && currentItemIndex < items.Count)
        {
            items.RemoveAt(currentItemIndex);
            slots[currentItemIndex].sprite = SlotIcon;
            if (currentItemIndex > 0)
                currentItemIndex = 0;
        }
    }

    public void UseCurrentItem()
    {
        if (currentItemIndex >= 0 && currentItemIndex < items.Count)
        {
            InventoryItem currentItem = items[currentItemIndex];
            if (currentItem != null)
            {
                switch (currentItem.itemsType)
                {
                    case ItemsType.Water:
                        Player.ChangeHungry(currentItem.AddFood);
                        Player.ChangeThirsty(currentItem.AddWater);
                        Debug.Log("Using Water");
                        break;
                    case ItemsType.Food:
                        Player.ChangeHungry(currentItem.AddFood);
                        Player.ChangeThirsty(currentItem.AddWater);
                        Debug.Log("Using Food");
                        break;
                    case ItemsType.Ticket:
                        Debug.Log("Using Ticket");
                        break;
                    case ItemsType.Instrument:
                        MB.SendMessage("Cant use it now");
                        Debug.Log("Using Instrument");
                        break;
                    case ItemsType.Gun:
                        Debug.Log("Using Gun");
                        break;
                    default:
                        Debug.Log("Unknown item type");
                        break;
                }
            }
        }
    }

    public void MoveToBox()
    {
        if (currentItemIndex >= 0 && currentItemIndex < items.Count && currentBox.items.Count<currentBox.Capacity)
        {
            InventoryItem item = items[currentItemIndex];
            currentBox.AddObj(item);
            RemoveObj();
        }
    }

    public void MoveFromBox()
    {
        if (currentBox.items.Count > currentBox.currentItemIndex)
        {
            InventoryItem item = currentBox.GetItem(currentBox.currentItemIndex);
            if (item != null)
            {
                AddObj(item);
                currentBox.RemoveObj();
                currentBox.currentItemIndex = 0;
            }
        }
    }

    public void ChangeCurrentItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            currentItemIndex = index;
        }
    }


    private void Update()
    {
        if (items.Count > currentItemIndex && items[currentItemIndex] != null)
        {
            DescriptionText.text = items[currentItemIndex].description;
            NameText.text = items[currentItemIndex].name;
        }
        else
        {
            DescriptionText.text = "description of Item";
            NameText.text = "Name of Item";
        }
    }

    public bool IsFull()
    {
        if (items.Count >= Capacity) return true;
        else return false;
    }
    public bool HasItem(InventoryItem item)
    {
        foreach (InventoryItem inventoryItem in items)
        {
            if (inventoryItem == item)
            {
                return true;
            }
        }
        return false;
    }


    public void SaveInventoryToJson()
    {
        string jsonData = JsonUtility.ToJson(new InventoryData(items));
        File.WriteAllText(Application.persistentDataPath + "/inventory.json", jsonData);
        Debug.Log("Inventory saved to JSON.");
    }

    public void LoadInventoryFromJson()
    {
        string filePath = Application.persistentDataPath + "/inventory.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonData);
            items = inventoryData.items;
            Debug.Log("Inventory loaded from JSON.");
        }
        else
        {
            Debug.LogWarning("Inventory JSON file not found.");
        }
    }
    public bool CanFitItemsInInventory(int numOfItems)
    {
        int remainingCapacity = Capacity - items.Count;

        bool CanFit = remainingCapacity >= numOfItems;
        Debug.Log("Can Fit" + CanFit);
        return CanFit;
    }

    [System.Serializable]
    private class InventoryData
    {
        public List<InventoryItem> items;

        public InventoryData(List<InventoryItem> items)
        {
            this.items = items;
        }
    }
}
