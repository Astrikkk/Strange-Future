using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public string NameOfShop;
    public List<InventoryItem> items;
    public List<int> price;
    private Inventory inventory;
    public BuyManager BM;
    private int numberOdItem;
    private MassageBox MB;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        BM = FindObjectOfType<BuyManager>();
        MB = FindObjectOfType<MassageBox>();
    }

    public void Choose()
    {
        if (Player.Money >= price[numberOdItem])
        {
            if (inventory.items.Count < inventory.Capacity)
            {
                Player.Money -= price[numberOdItem];
                inventory.AddObj(items[numberOdItem]);
            }
            else
            {
                MB.NoSpaceInInventoryMessage();
            }
        }
        else
        {
            MB.SendMessageNotEnoughMoney();
        }
        BM.BuymanagerObj.SetActive(false);
    }

    public void Buy(int a)
    {
        numberOdItem = a;

        BM.BuymanagerObj.SetActive(true);
        UnityEvent buyEvent = new UnityEvent();
        buyEvent.AddListener(Choose);
        BM.AssignButtonClickEvent(buyEvent);
        BM.NameOfItemText.text = items[a].name[LanguageManager.LanguageIndex];
        BM.PriceText.text = price[a].ToString() + "$";
        BM.image.sprite = items[a].icon;
    }

}
