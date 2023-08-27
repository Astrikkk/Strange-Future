using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    void Save();
    void Load();
}

public class NPCsaveManager : MonoBehaviour
{
    public List<ISaveable> saveableObjects = new List<ISaveable>();

    private void Awake()
    {
        ISaveable[] saveables = GetComponents<ISaveable>();
        saveableObjects.AddRange(saveables);
    }
    public void SaveAllObjects()
    {
        foreach (ISaveable saveableObject in saveableObjects)
        {
            saveableObject.Save();
        }
    }

    public void LoadAllObjects()
    {
        foreach (ISaveable saveableObject in saveableObjects)
        {
            saveableObject.Load();
        }
    }
}
