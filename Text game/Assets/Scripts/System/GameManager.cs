using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Player player;
    public InventoriesManager IM;
    public MenuManager MM;
    public bool NeedDoResetData;

    private void Start()
    {
        MM = gameObject.GetComponent<MenuManager>();
        if (NeedDoResetData)
            SavePlayerData();
        LoadPlayerData();
    }

    private void SavePlayerData()
    {
        player.SavePlayerData();
        IM.SaveAllInventoriesToJson();
        MM.SaveToPlayerPrefs();
    }

    private void LoadPlayerData()
    {
        player.LoadPlayerData();
        IM.LoadAllInventoriesFromJson();
        MM.LoadFromPlayerPrefs();
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
}
