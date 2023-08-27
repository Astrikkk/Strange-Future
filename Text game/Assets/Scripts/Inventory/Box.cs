using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Box : MonoBehaviour
{
    public InventoriesManager IM;
    public List<InventoryItem> items;
    public int Capacity;
    public Image[] slots;
    public int currentItemIndex = 0;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI NameOfBox;
    public Inventory inventory;
    public Color ChoosenSlot;
    public Color Defaultcolor;


    public void ShowIcon()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].sprite = items[i].icon;
            else slots[i].sprite = inventory.SlotIcon;
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

    public void RemoveObj()
    {
        if (currentItemIndex >= 0 && currentItemIndex < items.Count)
        {
            items.RemoveAt(currentItemIndex);
            slots[currentItemIndex].sprite = inventory.SlotIcon;
            if (currentItemIndex > 0)
                currentItemIndex = 0;
        }
    }

    public InventoryItem GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        return null;
    }
    public void ChangeCurrentItem(int index)
    {
        slots[currentItemIndex].color = Defaultcolor;
        if (index >= 0 && index < items.Count)
        {
            currentItemIndex = index;
            slots[currentItemIndex].color = ChoosenSlot;
        }
    }

    public void SaveInventoryToJson()
    {
        string jsonData = JsonUtility.ToJson(new InventoryData(items));
        File.WriteAllText(Application.persistentDataPath + "/box_inventory.json", jsonData);
        Debug.Log("Box inventory saved to JSON.");
    }

    public void LoadInventoryFromJson()
    {
        string filePath = Application.persistentDataPath + "/box_inventory.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonData);
            items = inventoryData.items;
            Debug.Log("Box inventory loaded from JSON.");
        }
        else
        {
            Debug.LogWarning("Box inventory JSON file not found.");
        }
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

    private void Update()
    {
        if (IM.boxes[IM.currentBox] == gameObject.GetComponent<Box>())
        {
            if (items.Count > currentItemIndex && items[currentItemIndex] != null)
            {
                DescriptionText.text = items[currentItemIndex].description[LanguageManager.LanguageIndex];
                NameText.text = items[currentItemIndex].name[LanguageManager.LanguageIndex];
            }
            else
            {
                DescriptionText.text = "description of Item";
                NameText.text = "Name of Item";
            }
            currentItemIndex = IM.currentItemIndex;
        }
    }
}