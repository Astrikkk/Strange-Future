using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cafe Item", menuName = "Inventory/Cafe Item")]
public class CafeItem : ScriptableObject
{
    public Sprite icon;
    public List<string> name;
    public int Price;
    public int AddFood;
    public int AddWater;
    public int TimeToEat;
    public string TimeString;
}