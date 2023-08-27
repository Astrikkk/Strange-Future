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
                SendMessagebar("����������� ������");
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
                SendMessagebar("������ ������ ������");
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
                SendMessagebar("�� ��� ��� �������");
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
                SendMessagebar("�� ��� �� �������");
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
                SendMessagebar("�� �� ����� ����� ����");
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
                SendMessagebar("� ���� ���� �����");
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
                SendMessagebar("�� �� ����� ��� �������, ����� ����������");
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
                SendMessagebar("� ���� ���� ���������� �������");
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
                SendMessagebar("���� ���� � ��������");
                break;
        }
    }

    public void CantUseItNowMessage()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("Cantt use it now");
                break;
            case 1:
                SendMessagebar("�� ���� �� ����������� �����");
                break;
        }
    }
    public void CantWorkBadMood()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I cant work when I'm in bad mood");
                break;
            case 1:
                SendMessagebar("� �� ���� ��������� � ������� �������");
                break;
        }
    }
    public void CantWorkHungry()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I cant work when I'm hungry");
                break;
            case 1:
                SendMessagebar("� �� ���� ��������� ���� � ��������");
                break;
        }
    }
    public void CantWorkThirsty()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I cant work when I'm thirsty");
                break;
            case 1:
                SendMessagebar("� �� ���� ��������� ���� � ���� ����");
                break;
        }
    }
    public void CantWorkSleepy()
    {
        switch (LanguageManager.LanguageIndex)
        {
            case 0:
                SendMessagebar("I cant work when I'm want to sleep");
                break;
            case 1:
                SendMessagebar("� �� ���� ��������� ���� � ���� �����");
                break;
        }
    }

    public void SendMessagebar(string message)
    {
        Box.SetActive(true);
        text.text = message;
    }
}
