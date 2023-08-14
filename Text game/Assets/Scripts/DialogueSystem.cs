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
        Speaker.sprite = currentDialogue.dialoque.Person[0];
        DialogueText.text = currentDialogue.dialoque.Text[0];
    }

    public void Next()
    {
        if (currentDialogue.dialoque.Text.Count > DialogueIndex)
        {
            DialogueIndex++;
            Speaker.sprite = currentDialogue.dialoque.Person[DialogueIndex];
            DialogueText.text = currentDialogue.dialoque.Text[DialogueIndex];
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
