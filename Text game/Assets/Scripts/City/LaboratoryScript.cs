using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool HaveBlueprint;
    private MassageBox MB;
    public bool CanEnter;
    private MenuManager MM;
    private City city;



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
            MM.ChangeMenu(8);
            city.Travel(9);
        }
        else
        {
            MB.SendMessage("You cant enter this place !!");
        }
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
