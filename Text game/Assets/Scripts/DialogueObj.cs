using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObj : ScriptableObject
{
    public Sprite BackGround;
    public Dialoque dialoque;
    public List<InventoryItem> ItemsGiven;
}

public struct Dialoque
{
    public List<Sprite> Person;
    public List<string> Text;
}
