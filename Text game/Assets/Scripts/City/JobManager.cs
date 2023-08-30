using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    private WaitManager WM;
    private MassageBox MB;
    private Timer timer;

    private void Start()
    {
        WM = GameObject.FindFirstObjectByType<WaitManager>();
        MB = GameObject.FindFirstObjectByType<MassageBox>();
        timer = GameObject.FindFirstObjectByType<Timer>();
    }

    public void Work(JobObj job)
    {
        if (Player.Mood < 10)
        {
            MB.CantWorkBadMood();
        }
        else if (Player.Hungry < 10)
        {
            MB.CantWorkHungry();
        }
        else if (Player.Thirsty < 10)
        {
            MB.CantWorkThirsty();
        }
        else if (Player.Sleepy < 10)
        {
            MB.CantWorkSleepy();
        }
        else if (job == Player.job)
        {
            Player.ChangeMoney(Player.job.salary);
            WM.SetTime(Player.job.TimeOfWorking);
            WM.SetTimeType(TypeOfActivity.Working);
            timer.AddHours(job.HoursWorking);
            Player.ChangeEnergy(-50);
            Player.ChangeHungry(-60);
            Player.ChangeThirsty(-40);
            Player.ChangeMood(-30);
            Player.ChangeSleepy(-50);
        }
        else MB.NotWorkingHereMessage();
    }
    public void ChooseJob(JobObj job)
    {
        if (job == Player.job) MB.AlreadyWorkingMessage();
        else
        {
            Player.job = job;
            MB.ChangeTaskSuccessMessage();
        }
    }
}
