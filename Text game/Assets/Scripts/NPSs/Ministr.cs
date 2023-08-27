using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ministr : MonoBehaviour, ISaveable
{
    public DialogueObj FirstDialoque;
    public DialogueObj GoAway;
    public DialogueObj Welcome;

    private DialogueSystem DS;
    private Timer timer;
    private MassageBox MB;
    private bool firstMeet = true;
    private bool secondMeet = true;

    private const string FirstMeetKey = "FirstMeetMinistr";
    private const string SecondMeetKey = "SecondMeetMinistr";

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        MB = GameObject.FindObjectOfType<MassageBox>();
        DS = GameObject.FindObjectOfType<DialogueSystem>();

        LoadData();
    }

    public void Talk()
    {
        if (firstMeet)
        {
            DS.LaunchDialogue(FirstDialoque);
            firstMeet = false;
            SaveData();
        }
        else if (!firstMeet && secondMeet && timer.CurrentHour == 0 && !LaboratoryScript.CanEnter)
        {
            DS.LaunchDialogue(Welcome);
            secondMeet = false;
            LaboratoryScript.CanEnter = true;
        }
        else
        {
            DS.LaunchDialogue(GoAway);
        }
    }

    void ISaveable.Save()
    {
        PlayerPrefs.SetInt(FirstMeetKey, firstMeet ? 1 : 0);
        PlayerPrefs.SetInt(SecondMeetKey, secondMeet ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ISaveable.Load()
    {
        if (PlayerPrefs.HasKey(FirstMeetKey))
        {
            int firstMeetValue = PlayerPrefs.GetInt(FirstMeetKey);
            firstMeet = firstMeetValue == 1;
        }

        if (PlayerPrefs.HasKey(SecondMeetKey))
        {
            int secondMeetValue = PlayerPrefs.GetInt(SecondMeetKey);
            secondMeet = secondMeetValue == 1;
        }
    }

    private void SaveData()
    {
        ISaveable saveable = this;
        saveable.Save();
    }

    private void LoadData()
    {
        ISaveable saveable = this;
        saveable.Load();
    }
}
