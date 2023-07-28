using UnityEngine;
using UnityEngine.Events;
using System;
using System.IO;

[System.Serializable]
public class WaitAction : MonoBehaviour
{
    public DateTime targetDate;
    public string ActionText;

    private const string TargetDateKey = "WaitAction_TargetDate";

    public void Start()
    {
        LoadFromPlayerPrefs();
    }

    public bool IsTargetDateReached()
    {
        return DateTime.Now >= targetDate;
    }
    public TimeSpan GetTimeRemaining()
    {
        if (IsTargetDateReached())
        {
            return TimeSpan.Zero;
        }
        else
        {
            return targetDate - DateTime.Now;
        }
    }


    public void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetString(TargetDateKey, targetDate.ToBinary().ToString());
    }

    public void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(TargetDateKey))
        {
            long targetDateBinary = long.Parse(PlayerPrefs.GetString(TargetDateKey));
            targetDate = System.DateTime.FromBinary(targetDateBinary);
        }
    }
}
