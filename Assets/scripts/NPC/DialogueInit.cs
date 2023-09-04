using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInit : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();

    void Start()
    {
        GetDialogueTexts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetDialogueTexts()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.portuguese:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControl.idiom.english:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControl.idiom.french:
                    sentences.Add(dialogue.dialogues[i].sentence.french);
                    break;
                default:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

            }
        }
    }

    // Chamado pelo sistema de física do Unity
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        // Criar esfera de colisão
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
