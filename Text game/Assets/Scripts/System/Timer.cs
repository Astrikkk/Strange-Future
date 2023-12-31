﻿using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;

    public int CurrentHour = 0;


    private void Start()
    {
        ShowData();
    }

    public void AddHours(int hours)
    {
        CurrentHour = (CurrentHour + hours) % 24;
        ShowData();
        SaveData();
    }
    public void ShowData()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                TimeText.text = "Time: " + CurrentHour.ToString() + " H.";
                break;
            case 1:
                TimeText.text = "×àñ: " + CurrentHour.ToString() + " ãîä.";
                break;
            default:
                TimeText.text = "Time: " + CurrentHour.ToString() + " H.";
                break;
        }

    }


    private const string TimerKey = "CurrentHour";

    public void SaveData()
    {
        PlayerPrefs.SetInt(TimerKey, CurrentHour);
        PlayerPrefs.Save();
        Debug.Log("Timer saved");
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(TimerKey))
        {
            CurrentHour = PlayerPrefs.GetInt(TimerKey);
            Debug.Log("Timer not loaded");
        }
        Debug.Log("Timer loaded");
    }
}