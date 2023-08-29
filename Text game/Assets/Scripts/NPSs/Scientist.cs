using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scientist : MonoBehaviour
{
    public DialogueObj FirstDialogue;
    public DialogueObj GoAway;
    public DialogueObj AllItemsCollected;

    private DialogueSystem DS;
    private bool FirstMeet;
    private LaboratoryScript lab;

    private const string SaveFileName = "ScientistSave.json";

    [System.Serializable]
    private class ScientistSaveData
    {
        public bool FirstMeet;
    }

    private void Start()
    {
        lab = FindObjectOfType<LaboratoryScript>();
        DS = FindObjectOfType<DialogueSystem>();
    }

    public void Talk()
    {
        if (FirstMeet)
        {
            DS.LaunchDialogue(FirstDialogue);
            FirstMeet = false;
        }
        else if (lab.RequiredItems.Count == 0)
        {
            DS.LaunchDialogue(AllItemsCollected);
        }
        else
        {
            DS.LaunchDialogue(GoAway);
        }
    }

    public void LoadData()
    {
        if (File.Exists(GetSavePath()))
        {
            string json = File.ReadAllText(GetSavePath());
            ScientistSaveData saveData = JsonUtility.FromJson<ScientistSaveData>(json);
            FirstMeet = saveData.FirstMeet;
        }
    }

    public void SaveData()
    {
        ScientistSaveData saveData = new ScientistSaveData();
        saveData.FirstMeet = FirstMeet;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(GetSavePath(), json);
    }

    private string GetSavePath()
    {
        return Path.Combine(Application.persistentDataPath, SaveFileName);
    }
}
