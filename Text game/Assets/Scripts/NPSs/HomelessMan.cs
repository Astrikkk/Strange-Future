using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessMan : MonoBehaviour, ISaveable
{
    public DialogueObj FirstDialoque;
    public DialogueObj DontDistarbeMe;
    public DialogueObj GoAway;
    public DialogueObj Blueprint;

    private DialogueSystem DS;
    private Timer timer;
    private MassageBox MB;
    private Inventory Inventory;
    private bool firstMeet = true;

    private const string FirstMeetKey = "FirstMeetHomelessMan";

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        MB = GameObject.FindObjectOfType<MassageBox>();
        DS = GameObject.FindObjectOfType<DialogueSystem>();
        Inventory = GameObject.FindObjectOfType<Inventory>();

        LoadFirstMeet();
    }


    public void Talk()
    {
        if (firstMeet)
        {
            DS.LaunchDialogue(FirstDialoque);
            firstMeet = false;
            SaveFirstMeet();
        }
        else if (LaboratoryScript.CanEnter && !LaboratoryScript.HaveBlueprint)
        {
            DS.LaunchDialogue(Blueprint);
            Inventory.AddObj(Inventory.AllExistItems[16]);
        }
        else if (timer.CurrentHour >= 7 && timer.CurrentHour < 20)
        {
            DS.LaunchDialogue(DontDistarbeMe);
        }
        else if (timer.CurrentHour >=20 || timer.CurrentHour < 7)
        {
            DS.LaunchDialogue(GoAway);
        }
        Save();
    }




    private void LoadFirstMeet()
    {
        if (PlayerPrefs.HasKey(FirstMeetKey))
        {
            int firstMeetValue = PlayerPrefs.GetInt(FirstMeetKey);
            firstMeet = firstMeetValue == 1;
        }
    }

    private void SaveFirstMeet()
    {
        int firstMeetValue = firstMeet ? 1 : 0;
        PlayerPrefs.SetInt(FirstMeetKey, firstMeetValue);
        PlayerPrefs.Save();
    }

    public void Save()
    {
        if (PlayerPrefs.HasKey(FirstMeetKey))
        {
            int firstMeetValue = PlayerPrefs.GetInt(FirstMeetKey);
            firstMeet = firstMeetValue == 1;
        }
    }

    public void Load()
    {
        int firstMeetValue = firstMeet ? 1 : 0;
        PlayerPrefs.SetInt(FirstMeetKey, firstMeetValue);
        PlayerPrefs.Save();
    }
}
