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
    public List<GameObject> gameObjectsToCheck = new List<GameObject>();

    private void Awake()
    {
        CollectSaveableObjects();
    }

    private void CollectSaveableObjects()
    {
        foreach (GameObject gameObjectToCheck in gameObjectsToCheck)
        {
            ISaveable saveable = gameObjectToCheck.GetComponent<ISaveable>();
            if (saveable != null)
            {
                saveableObjects.Add(saveable);
            }
        }
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
