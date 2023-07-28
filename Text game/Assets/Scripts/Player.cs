using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;



[System.Serializable]
public class PlayerData
{
    public float HP;
    public float Hungry;
    public float Thirsty;
    public float Energy;
    public float Health;
    public float Sleepy;
    public float Mood;
    public int Money;
    public int Age;
}

public class Player : MonoBehaviour
{
    public static float HP = 100;
    public static float Hungry = 100;
    public static float Thirsty = 100;
    public static float Energy = 100;
    public static float Health = 100;
    public static float Sleepy = 100;
    public static float Mood = 100;
    public static int Money = 100;
    
    
    public static float HPMax = 100;
    public static float HungryMax = 100;
    public static float ThirstyMax = 100;
    public static float EnergyMax = 100;
    public static float HealthMax = 100;
    public static float SleepyMax = 100;
    public static float MoodMax = 100;


    public TextMeshProUGUI HPtext;
    public TextMeshProUGUI HungryText;
    public TextMeshProUGUI ThirstyText;
    public TextMeshProUGUI EnergyText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI SleepyText;
    public TextMeshProUGUI MoodText;
    public TextMeshProUGUI MoneyText;

    private PlayerData playerData = new PlayerData();



    private void Start()
    {
        UpdateStatsText();
    }
    private void FixedUpdate()
    {
        UpdateStatsText();
    }








    public static void ChangeHP(float value)
    {
        HP += value;
        if (HP > HPMax) HP = HPMax;
        if (HP < 0) HP = 0;
    }
    public static void ChangeHungry(float value)
    {
        Hungry += value;
        if (Hungry > HungryMax) Hungry = HungryMax;
        if (Hungry < 0) Hungry = 0;
    }
    public static void ChangeThirsty(float value)
    {
        Thirsty += value;
        if (Thirsty > ThirstyMax) Thirsty = ThirstyMax;
        if (Thirsty < 0) Thirsty = 0;
    }
    public static void ChangeEnergy(float value)
    {
        Energy += value;
        if (Energy > EnergyMax) Energy = EnergyMax;
        if (Energy < 0) Energy = 0;
    }
    public static void ChangeHealth(float value)
    {
        Health += value;
        if (Health > HealthMax) Health = HealthMax;
        if (Health < 0) Health = 0;
    }
    public static void ChangeSleepy(float value)
    {
        Sleepy += value;
        if (Sleepy > SleepyMax) Sleepy = SleepyMax;
        if (Sleepy < 0) Sleepy = 0;
    }
    public static void ChangeMood(float value)
    {
        Mood += value;
        if (Mood > MoodMax) Mood = MoodMax;
        if (Mood < 0) Mood = 0;
    }
    public static void ChangeMoney(int value)
    {
        Money += value;
        if (Money < 0) Money = 0;
    }


    private void UpdateStatsText()
    {
        HPtext.text = HP.ToString() + " HP";
        HungryText.text = Hungry.ToString() + " Hungry";
        ThirstyText.text = Thirsty.ToString() + " Thirsty";
        EnergyText.text = Energy.ToString() + " Energy";
        HealthText.text = Health.ToString() + " Health";
        SleepyText.text = Sleepy.ToString() + " Sleepy";
        MoodText.text = Mood.ToString() + " Mood";
        MoneyText.text = Money.ToString() + " Money";
    }



    public void SavePlayerData()
    {
        playerData.HP = HP;
        playerData.Hungry = Hungry;
        playerData.Thirsty = Thirsty;
        playerData.Energy = Energy;
        playerData.Health = Health;
        playerData.Sleepy = Sleepy;
        playerData.Mood = Mood;
        playerData.Money = Money;

        string jsonData = JsonUtility.ToJson(playerData);

        string path = Application.persistentDataPath + "/playerData.json";
        File.WriteAllText(path, jsonData);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            HP = playerData.HP;
            Hungry = playerData.Hungry;
            Thirsty = playerData.Thirsty;
            Energy = playerData.Energy;
            Health = playerData.Health;
            Sleepy = playerData.Sleepy;
            Mood = playerData.Mood;
            Money = playerData.Money;

            UpdateStatsText();
        }
        else
        {
            Debug.LogWarning("No saved player data found.");
        }
    }


    public void DeleteSaveData()
    {
        string saveFileName = "playerData.json";
        string path = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data deleted.");
        }
        else
        {
            Debug.LogWarning("No save data found to delete.");
        }
    }
}