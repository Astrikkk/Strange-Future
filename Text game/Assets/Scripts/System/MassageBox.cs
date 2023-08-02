using UnityEngine;
using TMPro;

public class MassageBox : MonoBehaviour
{
    public GameObject Box;
    public TextMeshProUGUI text;

    public void SendMessage(string message)
    {
        Box.SetActive(true);
        text.text = message;
    }
}
