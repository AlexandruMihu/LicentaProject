using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCardPlayer : QuestCard
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI status;
    [SerializeField] private TextMeshProUGUI goldReward;
    [SerializeField] private TextMeshProUGUI expReward;

    [Header("Item")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemQuantity;

    [Header("Quest Completed")]
    [SerializeField] private GameObject claimButton;
    [SerializeField] private GameObject rewardsPanel;

    private void Update()
    {
       status.text = $"Status\n{QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        status.text = $"Status\n{quest.CurrentStatus}/{quest.QuestGoal}";
        goldReward.text = quest.GoldReward.ToString();
        expReward.text = quest.ExpReward.ToString();

        itemIcon.sprite = quest.ItemReward.Item.Icon;
        itemQuantity.text = quest.ItemReward.Quantity.ToString();
    }

    public void ClaimQuest()
    {
        QuestToComplete.RewardClaimed = true;

        GameManager.Instance.AddPlayerExp(QuestToComplete.ExpReward);
        Inventory.Instance.AddItem(QuestToComplete.ItemReward.Item, QuestToComplete.ItemReward.Quantity);
        CoinManager.Instance.AddCoins(QuestToComplete.GoldReward);
        QuestManager.Instance.SaveQuests();
        gameObject.SetActive(false);

        QuestManager.Instance.CheckIfAllQuestsClaimed();
    }


    private void QuestCompletedCheck()
    {
        if (QuestToComplete.QuestCompleted)
        {
            claimButton.SetActive(true);
            rewardsPanel.SetActive(false);
        }
    }

    private void OnEnable()
    {
        QuestCompletedCheck();
    }
}
