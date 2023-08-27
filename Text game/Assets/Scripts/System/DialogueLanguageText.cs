using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job object", menuName = "Special/DialoqueLanguage object")]
public class DialogueLanguageText : ScriptableObject
{
    public List<Sprite> Person;
    public List<string> Text;
}