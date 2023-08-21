using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject DialogMenu;
    public TextMeshProUGUI DialogueText;
    public Image BackGround;
    public Image Speaker;


    private DialogueObj currentDialogue;
    private int DialogueIndex;
    private Inventory Inventory;

    private void Start()
    {
        Inventory = GameObject.FindObjectOfType<Inventory>();
    }


    public void LaunchDialogue(DialogueObj LaunchedDialogue)
    {
        currentDialogue = LaunchedDialogue;
        DialogMenu.SetActive(true);
        BackGround.sprite = currentDialogue.BackGround;
        Speaker.sprite = currentDialogue.Person[0];
        DialogueText.text = currentDialogue.Text[0];
    }

    public void Next()
    {
        if (currentDialogue.Text.Count > DialogueIndex + 1)
        {
            DialogueIndex++;
            Speaker.sprite = currentDialogue.Person[DialogueIndex];
            DialogueText.text = currentDialogue.Text[DialogueIndex];
        }
        else
        {
            EndDialoque();
        }
    }

    public void EndDialoque()
    {
        DialogueIndex = 0;
        for (int i = 0; i < currentDialogue.ItemsGiven.Count; i++)
        {
            Inventory.AddObj(currentDialogue.ItemsGiven[i]);
        }
        DialogMenu.SetActive(false);
    }

}
