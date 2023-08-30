using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public enum TypeOfActivity { Eating, Sleeping, Working, Relaxing, Traveling }

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


    public void SetTimeTypeButtonEating()
    {
        SetTimeType(TypeOfActivity.Eating);
    }

    public void SetTimeTypeButtonSleaping()
    {
        SetTimeType(TypeOfActivity.Sleeping);
    }

    public void SetTimeTypeButtonWorking()
    {
        SetTimeType(TypeOfActivity.Working);
    }

    public void SetTimeTypeButtonRelaxing()
    {
        SetTimeType(TypeOfActivity.Relaxing);
    }

    public void SetTimeTypeButtonTraveling()
    {
        SetTimeType(TypeOfActivity.Traveling);
    }




    public void SetTimeType(TypeOfActivity type)
    {
        string Atext = GetActionTextByType(type);
        WA.ActionText = Atext;
        WA.SaveToPlayerPrefs();
        WaitMenu.SetActive(true);
    }
    private string GetActionTextByType(TypeOfActivity type)
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                switch (type)
                {
                    case TypeOfActivity.Eating:
                        return "Time to fill your stomach";
                    case TypeOfActivity.Sleeping:
                        return "*Sleeping*";
                    case TypeOfActivity.Working:
                        return "Working";
                    case TypeOfActivity.Relaxing:
                        return "Time to relax";
                    case TypeOfActivity.Traveling:
                        return "You are on the road";
                    default:
                        return "Unknown activity.";
                }
                break;
            case 1:
                switch (type)
                {
                    case TypeOfActivity.Eating:
                        return "Час поїсти";
                    case TypeOfActivity.Sleeping:
                        return "*Сплю*";
                    case TypeOfActivity.Working:
                        return "Працюю";
                    case TypeOfActivity.Relaxing:
                        return "Час відпочити";
                    case TypeOfActivity.Traveling:
                        return "Ви на дорозі";
                    default:
                        return "Невідома діяльність.";
                }
                break;
        }
        return null;

    }

}