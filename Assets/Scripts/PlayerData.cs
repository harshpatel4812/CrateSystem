using UnityEngine;

[CreateAssetMenu (fileName = "New Player", menuName = "Assets/Player")]
public class PlayerData : ScriptableObject
{
    public enum OpeningType { Single_Open,
                              Bulk_Open };
    
    public string PlayerID;
    public int CoinSpend;
    [Range(0f,100f)] public float LuckFactor;
    //public DateTime LastActiveDateTime;

    [Space]
    [Header ("Player pase kai type ni ketli Items chhe aenu counter")]
    public int CommonItemsCount;
    public int UncommonItemsCount;
    public int RareItemsCount;
    public int LegendaryItemsCount;
    public int MythicItemsCount;


    [Space]
    public OpeningType CrateOpeningStyle;

    public float TimeDelayBetweenCrate;
    
    [Range(0f,100f)] public int PlayerCurrentLevel;
    
    public bool BattlePassPurchased;

    public int CoinSpendLimitToChangeOddsForPlayer;

}
