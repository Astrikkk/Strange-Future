using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    private WaitManager WM;
    private MassageBox MB;


    private void Start()
    {
        WM = GameObject.FindFirstObjectByType<WaitManager>();
        MB = GameObject.FindFirstObjectByType<MassageBox>();
    }

    public void Work(JobObj job)
    {
        if (job == Player.job)
        {
            Player.ChangeMoney(Player.job.salary);
            WM.SetTime(Player.job.TimeOfWorking);
            WM.SetTime("Working");
        }
        else MB.SendMessage("You are not working here");
    }
    public void ChooseJob(JobObj job)
    {
        if (job == Player.job) MB.SendMessage("You are already workinhg here");
        else
        {
            Player.job = job;
            MB.SendMessage("Succesfully changed your job to " + job.Name);
        }
    }
}
