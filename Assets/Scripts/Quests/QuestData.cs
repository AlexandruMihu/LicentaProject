using System;

[Serializable]
public class QuestData
{
    public string[] QuestIDs;
    public int[] CurrentStatuses;
    public bool[] Accepted;
    public bool[] Completed;
    public bool[] RewardClaimed;
}