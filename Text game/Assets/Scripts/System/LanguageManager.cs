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

        List<TextLanguage> textLanguageComponents = new List<TextLanguage>(FindObjectsOfType<TextLanguage>());

        foreach (TextLanguage tlComponent in textLanguageComponents)
        {
            tlComponent.ChangeText();
        }
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