using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job object", menuName = "Special/Dialoque object")]
public class DialogueObj : ScriptableObject
{
    public Sprite BackGround;
    public List<Sprite> Person;
    public List<string> Text;
    public List<InventoryItem> ItemsGiven;
}
