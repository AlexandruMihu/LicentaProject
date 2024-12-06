using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class QuestManager:Singletone<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] quests;

    [Header("NPC Quest Panel")]
    [SerializeField] private QuestCardNPC questCardNpcPrefab;
    [SerializeField] private Transform npcPanelContainer;

    [Header("Player Quest Panel")]
    [SerializeField] private QuestCardPlayer questCardPlayerPrefab;
    [SerializeField] private Transform playerQuestContainer;

    private void Start()
    {
        LoadQuestIntoNPCPanel();
    }

    public void AcceptQuest(Quest quest)
    {
        QuestCardPlayer cardPlayer = Instantiate(questCardPlayerPrefab, playerQuestContainer);
        cardPlayer.ConfigQuestUI(quest);
    }

    public void AddProgress(string questID, int amount)
    {
        Quest questToUpdate = QuestExists(questID);
        if (questToUpdate == null) return;
        if (questToUpdate.QuestAccepted)
        {
            questToUpdate.AddProgress(amount);
        }
    }

    private Quest QuestExists(string questID)
    {
        foreach(Quest quest in quests) 
        {
            if(quest.ID == questID)
            {
                return quest;
            }
        }

        return null;
    }
    private void LoadQuestIntoNPCPanel()
    {
        for(int i = 0;i < quests.Length; i++)
        {
            QuestCard npcCard = Instantiate(questCardNpcPrefab,npcPanelContainer);
            npcCard.ConfigQuestUI(quests[i]);
        }
    }

    private void OnEnable()
    {
        for(int i = 0; i < quests.Length; i++)
        {
            quests[i].ResetQuest();
        }
    }
}

