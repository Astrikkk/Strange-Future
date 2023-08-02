using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job object", menuName = "Special/Job object")]
public class JobObj : ScriptableObject
{
    public string Name;
    public string description;
    public int salary;
    public int TimeOfWorking;
}
