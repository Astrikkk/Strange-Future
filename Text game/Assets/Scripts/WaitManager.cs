using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class WaitManager : MonoBehaviour
{
    public WaitAction WA;
    public GameObject WaitMenu;
    public TextMeshProUGUI ActionText;
    public TextMeshProUGUI TimeLeftText;

    private void Start()
    {
        WaitMenu.SetActive(true);
    }
    private void FixedUpdate()
    {
        TimeLeftText.text = WA.GetTimeRemaining().ToString();
        ActionText.text = WA.ActionText;
        if (WA.IsTargetDateReached())
        {
            WaitMenu.SetActive(false);
        }
    }

    public void SetTime(int endData)
    {
        DateTime targetDate = DateTime.Now.AddSeconds(endData);
        WA.targetDate = targetDate;
        WA.SaveToPlayerPrefs();
        WaitMenu.SetActive(true);
    }
    public void SetTime(string Atext)
    {
        WA.ActionText = Atext;
        WA.SaveToPlayerPrefs();
        WaitMenu.SetActive(true);
    }

}
