using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePannelScript : MonoBehaviour
{
    private bool IsOpened = false;
    public GameObject SideMenu;
    public void ShowPannel()
    {
        if (IsOpened)
        {
            SideMenu.SetActive(false);
            IsOpened = false;
        }
        else
        {
            SideMenu.SetActive(true);
            IsOpened = true;
        }
    }

    private void Update()
    {

    }
}