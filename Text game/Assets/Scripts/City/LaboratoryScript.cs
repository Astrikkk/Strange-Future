using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class LaboratoryData
{
    public List<InventoryItem> RequiredItems;
    public bool HaveBlueprint;
    public bool CanEnter;
}



public class LaboratoryScript : MonoBehaviour
{
    public List<InventoryItem> RequiredItems;
    private Inventory inventory;
    public static bool HaveBlueprint;
    private MassageBox MB;
    public static bool CanEnter;
    private MenuManager MM;
    private City city;
    public TextMeshProUGUI detailsText;



    private void Start()
    {
        MB = GameObject.FindAnyObjectByType<MassageBox>();
        MM = GameObject.FindAnyObjectByType<MenuManager>();
        city = GameObject.FindAnyObjectByType<City>();
        inventory = GameObject.FindAnyObjectByType<Inventory>();
    }

    public void EnterLaboratory()
    {
        if (CanEnter)
        {
            MM.ChangeMenu(10);
            city.Travel(8);
        }
        else
        {
            MB.CannotEnterMessage();
        }
    }

    public void PlaceAllItems()
    {
        if (HaveBlueprint)
        {
            bool hasRequiredItem = false;

            for (int j = 0; j < RequiredItems.Count; j++)
            {
                InventoryItem requiredItem = RequiredItems[j];

                if (inventory.HasItem(requiredItem))
                {
                    hasRequiredItem = true;
                    inventory.RemoveItem(requiredItem);
                    RemoveRequiredItem(requiredItem);
                }
            }

            if (!hasRequiredItem)
            {
                MB.DontHavetimeMachineItemsMessage();
            }
        }
        else
        {
            MB.NoBlueprintMessage();
        }
    }

    public void RemoveRequiredItem(InventoryItem item)
    {
        if (RequiredItems.Contains(item))
        {
            RequiredItems.Remove(item);
        }
    }

    private void FixedUpdate()
    {
        UpdateDetailsText();
    }

    public void UpdateDetailsText()
    {
        string itemsText = "";
        foreach (InventoryItem requiredItem in RequiredItems)
        {
            itemsText += requiredItem.name[LanguageManager.LanguageIndex] + "\n";
        }
        detailsText.text = itemsText;
    }

    public void SaveData()
    {
        LaboratoryData data = new LaboratoryData
        {
            HaveBlueprint = HaveBlueprint,
            CanEnter = CanEnter,
            RequiredItems = RequiredItems
        };

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("LaboratoryData", json);
    }

    public void LoadData()
    {
        string json = PlayerPrefs.GetString("LaboratoryData", "");
        if (!string.IsNullOrEmpty(json))
        {
            LaboratoryData data = JsonUtility.FromJson<LaboratoryData>(json);

            HaveBlueprint = data.HaveBlueprint;
            CanEnter = data.CanEnter;
            RequiredItems = data.RequiredItems;
        }
    }



}
