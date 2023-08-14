using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Player player;
    public InventoriesManager IM;
    public MenuManager MM;
    public City city;
    public bool NeedDoResetData;
    private LaboratoryScript Lab;

    private void Start()
    {
        Lab = FindObjectOfType<LaboratoryScript>();
        MM = gameObject.GetComponent<MenuManager>();
        LoadResetStatus();
        if (NeedDoResetData)
        {
            SavePlayerData();
            NeedDoResetData = false;
            SaveResetStatus();
        }
        LoadPlayerData();
    }

    private void SavePlayerData()
    {
        player.SavePlayerData();
        IM.SaveAllInventoriesToJson();
        MM.SaveToPlayerPrefs();
        city.SaveData();
        Lab.SaveData();
    }

    private void LoadPlayerData()
    {
        player.LoadPlayerData();
        IM.LoadAllInventoriesFromJson();
        MM.LoadFromPlayerPrefs();
        city.LoadData();
        Lab.LoadData();
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
