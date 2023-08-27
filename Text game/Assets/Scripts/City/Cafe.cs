using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cafe : MonoBehaviour
{
    public string NameOfCafe;
    public WaitManager WM;
    public GameObject CafeBuyMenu;
    private BuyManager BM;
    private MassageBox MB;
    private Timer timer;

    private CafeItem currentItem;
    public void Buy()
    {
        if (Player.Money >= currentItem.Price && currentItem != null)
        {
            Player.Money -= currentItem.Price;
            Player.ChangeHungry(currentItem.AddFood);
            Player.ChangeThirsty(currentItem.AddWater);
            WM.SetTime(currentItem.TimeToEat);
            WM.SetTimeType(TypeOfActivity.Eating);
            timer.AddHours(1);
        }
        else
        {
            MB.SendMessageNotEnoughMoney();
        }
        BM.BuymanagerObj.SetActive(false);
    }

    private void Start()
    {
        WM=GameObject.FindAnyObjectByType<WaitManager>();
        BM = FindObjectOfType<BuyManager>();
        timer = FindObjectOfType<Timer>();
        MB = FindObjectOfType<MassageBox>();
    }

    public void Eat(CafeItem item)
    {
        currentItem = item;
        BM.BuymanagerObj.SetActive(true);
        UnityEvent buyEvent = new UnityEvent();
        buyEvent.AddListener(Buy);
        BM.AssignButtonClickEvent(buyEvent);
        BM.NameOfItemText.text = currentItem.name[LanguageManager.LanguageIndex];
        BM.PriceText.text = currentItem.Price.ToString() + "$";
        BM.image.sprite = currentItem.icon;
    }
}
