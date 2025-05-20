using BayatGames.SaveGameFree;
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

    [Header("Completion Reward Sprite")]
    [SerializeField] private GameObject allQuestsCompletedSprite;

    private const string QUEST_KEY = "MY_QUESTS";

    private void Start()
    {
        LoadQuests();
        LoadQuestIntoNPCPanel();
        LoadAcceptedQuests();
    }
    private void LoadAcceptedQuests()
    {
        foreach (Quest q in quests)
        {
            if (q.QuestAccepted)
            {
                QuestCardPlayer card = Instantiate(questCardPlayerPrefab, playerQuestContainer);
                card.ConfigQuestUI(q);
            }
        }
    }

    public void AcceptQuest(Quest quest)
    {
        quest.QuestAccepted = true;
        SaveQuests();
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
        SaveQuests();
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
        foreach (Quest q in quests)
        {
            if (!q.QuestAccepted)
            {
                QuestCardNPC card = Instantiate(questCardNpcPrefab, npcPanelContainer);
                card.ConfigQuestUI(q);
            }
        }
    }

    private bool AllQuestsCompleted()
    {
        foreach (Quest quest in quests)
        {
            if (!quest.QuestCompleted)
                return false;
        }
        return true;
    }

    public void CheckIfAllQuestsClaimed()
    {
        foreach (Quest quest in quests)
        {
            if (!quest.QuestCompleted || !quest.RewardClaimed)
                return;
        }

        allQuestsCompletedSprite.SetActive(true);
    }

    private void OnEnable()
    {
        for(int i = 0; i < quests.Length; i++)
        {
            quests[i].ResetQuest();
        }
    }
    public void LoadQuests()
    {
        if (!SaveGame.Exists(QUEST_KEY)) return;
        QuestData data = SaveGame.Load<QuestData>(QUEST_KEY);

        for (int i = 0; i < quests.Length; i++)
        {
            Quest q = quests[i];
            int idx = Array.IndexOf(data.QuestIDs, q.ID);
            if (idx < 0) continue;
            q.CurrentStatus = data.CurrentStatuses[idx];
            q.QuestAccepted = data.Accepted[idx];
            q.QuestCompleted = data.Completed[idx];
            q.RewardClaimed = data.RewardClaimed[idx];
        }
    }

    public void SaveQuests()
    {
        QuestData data = new QuestData();
        int count = quests.Length;
        data.QuestIDs = new string[count];
        data.CurrentStatuses = new int[count];
        data.Accepted = new bool[count];
        data.Completed = new bool[count];
        data.RewardClaimed = new bool[count];

        for (int i = 0; i < count; i++)
        {
            Quest q = quests[i];
            data.QuestIDs[i] = q.ID;
            data.CurrentStatuses[i] = q.CurrentStatus;
            data.Accepted[i] = q.QuestAccepted;
            data.Completed[i] = q.QuestCompleted;
            data.RewardClaimed[i] = q.RewardClaimed;
        }

        SaveGame.Save(QUEST_KEY, data);
    }
}

