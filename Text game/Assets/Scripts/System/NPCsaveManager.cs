using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsaveManager : MonoBehaviour
{
    public Ministr ministr;
    public HomelessMan homelessMan;
    public Guard guard;
    public Scientist scientist;

    public void SaveAllNPC()
    {
        ministr.SaveData();
        homelessMan.SaveData();
        guard.SaveData();
        scientist.SaveData();
    }

    public void LoadAllNPC()
    {
        ministr.LoadData();
        homelessMan.LoadData();
        guard.LoadData();
        scientist.LoadData();
    }
}
