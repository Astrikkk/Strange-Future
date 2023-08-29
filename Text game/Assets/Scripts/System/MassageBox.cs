using UnityEngine;
using TMPro;

public class MassageBox : MonoBehaviour
{
    public GameObject Box;
    public TextMeshProUGUI text;

    public void SendMessageNotEnoughMoney()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("Not enough money");
                break;
            case 1:
                SendMessagebar("Недостатньо грошей");
                break;
        }
    }

    public void ChangeTaskSuccessMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("Successfully changed the job");
                break;
            case 1:
                SendMessagebar("Успішно змінили роботу");
                break;
        }
    }

    public void AlreadyWorkingMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You are already working here");
                break;
            case 1:
                SendMessagebar("Ви вже працюєте тут");
                break;
        }
    }

    public void NotWorkingHereMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You are not working here");
                break;
            case 1:
                SendMessagebar("Ви не працюєте тут");
                break;
        }
    }

    public void CannotEnterMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You cannot enter here");
                break;
            case 1:
                SendMessagebar("Вам не дозволено сюди входити");
                break;
        }
    }

    public void NoBlueprintMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You don't have the blueprint");
                break;
            case 1:
                SendMessagebar("У вас немає малюнка");
                break;
        }
    }

    public void CannotSwimMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You cannot swim here, it's too dangerous");
                break;
            case 1:
                SendMessagebar("Ви не можете плавати тут, це надто небезпечно");
                break;
        }
    }

    public void NoFishingRodMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("You don't have a fishing rod");
                break;
            case 1:
                SendMessagebar("У вас немає вудки для риболовлі");
                break;
        }
    }

    public void NoSpaceInInventoryMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("No space available in the inventory");
                break;
            case 1:
                SendMessagebar("Немає місця в інвентарі");
                break;
        }
    }

    public void CantUseItNowMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("Can't use it now");
                break;
            case 1:
                SendMessagebar("Зараз це не можна використовувати");
                break;
        }
    }

    public void CantWorkBadMood()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I can't work when I'm in a bad mood");
                break;
            case 1:
                SendMessagebar("Я не можу працювати, коли я в поганому настрої");
                break;
        }
    }

    public void CantWorkHungry()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I can't work when I'm hungry");
                break;
            case 1:
                SendMessagebar("Я не можу працювати, коли я голодний");
                break;
        }
    }

    public void CantWorkThirsty()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I can't work when I'm thirsty");
                break;
            case 1:
                SendMessagebar("Я не можу працювати, коли мені хочеться пити");
                break;
        }
    }

    public void CantWorkSleepy()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I can't work when I want to sleep");
                break;
            case 1:
                SendMessagebar("Я не можу працювати, коли мені хочеться спати");
                break;
        }
    }
     public void DontHavetimeMachineItemsMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I don't have any parts of time machine");
                break;
            case 1:
                SendMessagebar("Я не маю жодної запчастини для машини часу");
                break;
        }
    }

    public void SendMessagebar(string message)
    {
        Box.SetActive(true);
        text.text = message;
    }
}
