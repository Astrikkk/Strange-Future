using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class City : MonoBehaviour
{
    [System.Serializable]
    public class CityData
    {
        public string NameOfCity;
        public List<Shop> shops;
        public int OurPoint;
    }

    public string NameOfCity;
    public GameObject MapObj;
    public List<Shop> shops;
    public Image Map;
    public int OurPoint;
    public MenuManager MM;
    public GameObject PlayerPositionObj;

    public List<Transform> MapPoints;
    public List<GameObject> Marks;


    private bool IsOpenMap;
    private bool IsHidenMarks;
    private void Start()
    {
        LoadData();
    }


    public void HideShowMarks()
    {
        if (!IsHidenMarks)
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Marks[i].SetActive(false);
            }
            IsHidenMarks = true;
            PlayerPositionObj.SetActive(true);
        }
        else
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Marks[i].SetActive(true);
            }
            IsHidenMarks = false;
            PlayerPositionObj.SetActive(false);
        }
    }
    public void Travel(int a)
    {
        OurPoint = a;
        SaveData();
    }

    private void FixedUpdate()
    {
        PlayerPositionObj.transform.position = MapPoints[OurPoint].transform.position;
    }


    public bool GetOpen()
    {
        return IsOpenMap;
    }
    public void OpenMap()
    {
        if (IsOpenMap)
        {
            MapObj.SetActive(false);
            IsOpenMap = false;
            MM.menues[MM.currentMenu].Menu.SetActive(true);
            MM.Inventory.SetActive(false);
        }
        else
        {
            MM.menues[MM.currentMenu].Menu.SetActive(false);
            MapObj.SetActive(true);
            IsOpenMap = true;
            MM.Inventory.SetActive(false);
        }
    }
    public void SaveData()
    {
        CityData data = new CityData
        {
            NameOfCity = NameOfCity,
            shops = shops,
            OurPoint = OurPoint,
        };

        string json = JsonUtility.ToJson(data);
        string savePath = Application.persistentDataPath + "/city_data.json";

        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        string savePath = Application.persistentDataPath + "/city_data.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            CityData data = JsonUtility.FromJson<CityData>(json);

            NameOfCity = data.NameOfCity;
            shops = data.shops;
            OurPoint = data.OurPoint;

            PlayerPositionObj.transform.position = MapPoints[OurPoint].position;
        }
    }
}
