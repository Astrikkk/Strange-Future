using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
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
        LoadData();
    }

    public void Talk()
    {
        if (LaboratoryScript.CanEnter)
        {
            DS.LaunchDialogue(Welcome);
        }
        else if (firstMeet)
        {
            DS.LaunchDialogue(FirstDialoque);
            firstMeet = false;
            SaveData();
        }
        else
        {
            DS.LaunchDialogue(GoAway);
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(FirstMeetKey))
        {
            int firstMeetValue = PlayerPrefs.GetInt(FirstMeetKey);
            firstMeet = firstMeetValue == 1;
        }
    }

    public void SaveData()
    {
        int firstMeetValue = firstMeet ? 1 : 0;
        PlayerPrefs.SetInt(FirstMeetKey, firstMeetValue);
        PlayerPrefs.Save();
    }
}
