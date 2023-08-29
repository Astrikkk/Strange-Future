using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLanguage : MonoBehaviour
{
    public List<string> LanguageText;
    private TextMeshProUGUI text;
    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        ChangeText();
    }

    public void ChangeText()
    {
        text.text = LanguageText[LanguageManager.LanguageIndex];
    }
}