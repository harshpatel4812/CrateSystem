using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    public enum Rarity {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Mythic
    }

    public enum GuranteedRewardAt {
        No,
        After_100_spin,
        After_150_spin,
        After_200_spin,
        After_250_spin
    }

    public string itemId;
    public string itemName;
    public Rarity rarity;

    [Range( 0, 1000 )] public int BaseOdds;
    [Range( 0, 1000 )] public int RareOdds;
    public bool isRepeatable;
    public bool isGuranteedReward;
    public GuranteedRewardAt guranteedRewardAt;
    [Range( 0, 250 )] public int ChangeToRareOddsAfterThisNumberOfSpin;

    public int minusAfterEachSpin;


}
