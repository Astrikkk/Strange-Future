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
        public List<int> MapPointsMenu;
    }

    public string NameOfCity;
    public List<Shop> shops;
    public Image Map;
    public int OurPoint;
    public MenuManager MM;
    public GameObject PlayerPositionObj;

    public List<Transform> MapPoints;
    public List<int> MapPointsMenu;

    private void Start()
    {
        LoadData();
    }

    public void Travel(int a)
    {
        OurPoint = a;
        SaveData();
    }





    public void SaveData()
    {
        CityData data = new CityData
        {
            NameOfCity = NameOfCity,
            shops = shops,
            OurPoint = OurPoint,
            MapPointsMenu = MapPointsMenu
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
            MapPointsMenu = data.MapPointsMenu;

            PlayerPositionObj.transform.position = MapPoints[OurPoint].position;
        }
    }
}
