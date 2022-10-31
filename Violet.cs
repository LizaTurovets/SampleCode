using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Violet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject player;

    bool dialogue = false;
    int dialogueNum = -1;

    string[] quotes = new string[7]
    {
        "Violet: Hey, you’re not from around here.",
        "Rain: Where is here?",
        "Violet: This area on this side of the river — the village, the forest, the lake — the state of Eternia. ",
        "Violet: Why’d you come here if you don’t know where you are?",
        "Rain: I’m not sure. I was walking and walking and then I ended up in this place. Maybe there’s something I need to do?",
        "Violet: Well I hope you find whatever you’re looking for.",
        "Violet: If it's any help, a lot of people travel east in search of something. Maybe you're one of them."
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // moves to next dialogue
    void DialogueNext()
    {
        dialogueNum += 1;
        text.text = quotes[dialogueNum];
    }




    void OnDialogue()
    {
        
        if (dialogue && dialogueNum < 6)
        {
            DialogueNext();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogue = true;
            if (dialogueNum == -1)
            {
                text.text = "Rain: Hello.\nPress [space] to continue";
            }
            if (dialogueNum >= 0 && dialogueNum < 6)
            {
                text.text = quotes[dialogueNum];
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogue = false;
            text.text = "";
        }
    }
}
