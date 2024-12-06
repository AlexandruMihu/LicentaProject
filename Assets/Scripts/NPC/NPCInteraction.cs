using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class NPCInteraction : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private NPCDialogue dialogueToShow;
    [SerializeField] private GameObject interactionBox;

    private NPCMovement npcMovement;
    public NPCDialogue DialogueToShow => dialogueToShow;

    private void Awake()
    {
        npcMovement = GetComponent<NPCMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.NPCSelected = this;
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.NPCSelected = null;
            DialogueManager.Instance.CloseDialoguePanel();
            interactionBox.SetActive(false);
            if (npcMovement != null)
            {
                npcMovement.SetMovement(true);
            }
        }
    }
}
