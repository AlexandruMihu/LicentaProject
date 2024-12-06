using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singletone<DialogueManager>
{
    public static event Action<InteractionType> OnExtraInteractionEvent;

    [Header("Config")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcNameTMP;
    [SerializeField] private TextMeshProUGUI npcDialogueTMP;

    public NPCInteraction NPCSelected {  get; set; }

    private bool dialogueStarted;
    private PlayerActions actions;

    private Queue<string> dialogueQueue = new Queue<string>();

    protected override void Awake()
    {
        base.Awake();
        actions = new PlayerActions();
    }

    private void Start()
    {
        actions.Dialogue.Interact.performed += ctx => HandleDialog();
    }
    private void OnDestroy()
    {
        actions.Dialogue.Interact.performed -= ctx => HandleDialog();
    }

    public void CloseDialoguePanel()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
        dialogueStarted = false;
        dialogueQueue.Clear();
        if (NPCSelected != null && NPCSelected.TryGetComponent(out NPCMovement npcMovement))
        {
            npcMovement.SetMovement(true);
        }
    }

    private void LoadDialogueFromNPC()
    {
        if (NPCSelected.DialogueToShow.Dialogue.Length <= 0) return;
        foreach(string sentence in NPCSelected.DialogueToShow.Dialogue)
        {
            dialogueQueue.Enqueue(sentence);
        }
    }

    void HandleDialog()
    {
        if (NPCSelected == null || dialoguePanel == null)
            return;

        if (!dialogueStarted)
        {
            dialoguePanel.SetActive(true);
            LoadDialogueFromNPC();

            npcIcon.sprite = NPCSelected.DialogueToShow.Icon;
            npcNameTMP.text = NPCSelected.DialogueToShow.Name;
            npcDialogueTMP.text = NPCSelected.DialogueToShow.Greeting;
            dialogueStarted = true;

            if (NPCSelected.TryGetComponent(out NPCMovement npcMovement))
            {
                npcMovement.SetMovement(false);
            }
        }
        else
        {
            if (dialogueQueue.Count <= 0)
            {
                CloseDialoguePanel();
                if(NPCSelected.DialogueToShow.HasInteraction)
                {
                    OnExtraInteractionEvent?.Invoke(NPCSelected.DialogueToShow.InteractionType);
                }
            }
               
            else
                npcDialogueTMP.text = dialogueQueue.Dequeue();
        }
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
