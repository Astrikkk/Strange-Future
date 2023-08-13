using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class BuyManager : MonoBehaviour
{
    public GameObject BuymanagerObj;
    public Button BuyButton;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI NameOfItemText;
    public Image image;



    public void AssignButtonClickEvent(UnityEvent unityEvent)
    {
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => unityEvent.Invoke());
    }
}

