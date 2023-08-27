using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour, ISaveable
{
    public DialogueObj FirstDialoque;
    public DialogueObj GoAway;
    public DialogueObj Welcome;

    private DialogueSystem DS;
    private Timer timer;
    private MassageBox MB;
    private bool firstMeet = true;

    private const string FirstMeetKey = "FirstMeetGuard";

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        MB = GameObject.FindObjectOfType<MassageBox>();
        DS = GameObject.FindObjectOfType<DialogueSystem>();

        LoadFirstMeet();
    }


    public void Talk()
    {
        if (LaboratoryScript.CanEnter)
        {
            DS.LaunchDialogue(FirstDialoque);
            firstMeet = false;
            SaveFirstMeet();
        }
        else if (firstMeet)
        {
            DS.LaunchDialogue(Welcome);
        }
        else
        {
            DS.LaunchDialogue(GoAway);
        }
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
