using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Player player;
    public InventoriesManager IM;
    public MenuManager MM;
    public City city;
    public Timer timer;
    public NPCsaveManager NPCsave;
    public bool NeedDoResetData;
    private LaboratoryScript Lab;
    private LanguageManager Language;

    private void Awake()
    {
        Lab = FindObjectOfType<LaboratoryScript>();
        MM = gameObject.GetComponent<MenuManager>();
        timer = gameObject.GetComponent<Timer>();
        Language = gameObject.GetComponent<LanguageManager>();
        LoadResetStatus();
        if (NeedDoResetData == true)
        {
            MM.currentMenu = 0;
            NeedDoResetData = false;
            SaveResetStatus();
            SavePlayerData();
            player.DeleteSaveData();
        }
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        player.SavePlayerData();
        IM.SaveAllInventoriesToJson();
        MM.SaveToPlayerPrefs();
        city.SaveData();
        timer.SaveData();
        Lab.SaveData();
        NPCsave.SaveAllNPC();
        Language.SaveLanguage();
        SaveResetStatus();
    }

    public void LoadPlayerData()
    {
        player.LoadPlayerData();
        IM.LoadAllInventoriesFromJson();
        MM.LoadFromPlayerPrefs();
        city.LoadData();
        timer.LoadData();
        Lab.LoadData();
        NPCsave.LoadAllNPC();
        Language.LoadLanguage();
    }

    public void ResetData()
    {
        NeedDoResetData = true;
        SaveResetStatus();
        RestartScene();
    }


    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void SaveResetStatus()
    {
        PlayerPrefs.SetInt("ResetStatus", NeedDoResetData ? 1 : 0);
    }

    private void LoadResetStatus()
    {
        NeedDoResetData = PlayerPrefs.GetInt("ResetStatus", 0) == 1;
    }

}