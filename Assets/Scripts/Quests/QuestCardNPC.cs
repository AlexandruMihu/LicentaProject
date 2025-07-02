using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class QuestCardNPC:QuestCard
{
    [SerializeField] private TextMeshProUGUI questReward;

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        questReward.text = $"- {quest.GoldReward} Gold\n" +
            $"- {quest.ExpReward} Exp\n" +
            $"- x{quest.ItemReward.Quantity} {quest.ItemReward.Item.Name}";
    }

    public void AcceptQuest()
    {
        if (QuestToComplete == null) return;
        QuestToComplete.QuestAccepted = true;
        QuestManager.Instance.AcceptQuest(QuestToComplete);
        gameObject.SetActive(false);
    }
}

