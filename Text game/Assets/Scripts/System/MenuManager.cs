using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public MenuObj[] menues;
    public InventoriesManager IM;
    public GameObject box;
    public GameObject Inventory;
    public WaitManager WM;
    public City city;
    private GameManager GM;


    public int currentMenu = 0;
    private bool IsOpenInventory = false;

    private const string CurrentMenuKey = "CurrentMenu";

    private void Start()
    {
        for (int i = 0; i < menues.Length; i++)
        {
            menues[i].Menu.SetActive(false);
        }
        menues[currentMenu].Menu.SetActive(true);
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    public void ChangeMenu(int a)
    {
        menues[currentMenu].Menu.SetActive(false);
        menues[a].Menu.SetActive(true);
        if (menues[a].HaveBox)
        {
            box.SetActive(true);
            IM.currentBox = menues[a].BoxIndex;
        }
        else
        {
            box.SetActive(false);
        }
        currentMenu = a;
        IM.boxes[IM.currentBox].NameOfBox.text = menues[a].NameOfBox;
        GM.SavePlayerData();
    }
    public void OpenCloseInventory()
    {
        if (city.GetOpen()) city.OpenMap();
        if (IsOpenInventory)
        {
            Inventory.SetActive(false);
            IsOpenInventory = false;
            menues[currentMenu].Menu.SetActive(true);
        }
        else
        {
            menues[currentMenu].Menu.SetActive(false);
            Inventory.SetActive(true);
            IsOpenInventory = true;
        }
    }
    public void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt(CurrentMenuKey, currentMenu);
    }

    public void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(CurrentMenuKey))
        {
            currentMenu = PlayerPrefs.GetInt(CurrentMenuKey);
            menues[currentMenu].Menu.SetActive(true);
            IM.boxes[IM.currentBox].NameOfBox.text = menues[currentMenu].NameOfBox;
        }
    }



}
