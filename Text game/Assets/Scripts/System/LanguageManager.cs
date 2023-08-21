using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static int LanguageIndex;

    private const string LanguageKey = "LanguageIndex";

    private void Start()
    {
        LoadLanguage();
    }

    public void ChangeLanguage(int a)
    {
        LanguageIndex = a;
        SaveLanguage();
    }

    public void SaveLanguage()
    {
        PlayerPrefs.SetInt(LanguageKey, LanguageIndex);
        PlayerPrefs.Save();
    }

    public void LoadLanguage()
    {
        if (PlayerPrefs.HasKey(LanguageKey))
        {
            LanguageIndex = PlayerPrefs.GetInt(LanguageKey);
        }
        else
        {
            LanguageIndex = 0;
        }
    }
}
