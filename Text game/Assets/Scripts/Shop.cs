using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string NameOfShop;
    public List<InventoryItem> items;
    public List<int> price;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void Buy(int a)
    {
        if (Player.Money >= price[a]&& inventory.items.Count<inventory.Capacity)
        {
            Player.Money -= price[a];
            inventory.AddObj(items[a]);
        }
    }
}
