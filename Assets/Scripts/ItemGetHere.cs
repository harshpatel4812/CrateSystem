using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemGetHere : MonoBehaviour
{
    #region Declaration

    //Array arrayOf = Enum.GetValues(typeof(Item.GuranteedRewardAt));
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _scrollCount;
    [SerializeField] private TextMeshProUGUI _coinSpent;

    #endregion

    private void Start()
    {
        _coinSpent.text = Computational.instance.PlayerDataObjectHere.CoinSpend.ToString();
        //rewardItems.Clear();
    }


    /// <summary>
    /// This will get item name If item is guranteed reward or random
    /// </summary>
    private void GetItemName( bool LuckFactor )
    {
        if ( CrateItemsDatabase.spinCount == 99 )
        {
            //Debug.LogError( "100 Called" );
            GetItem( Item.GuranteedRewardAt.After_100_spin );
        }

        else if ( CrateItemsDatabase.spinCount == 149 )
        {
            //Debug.LogError( "150 Called" );
            GetItem( Item.GuranteedRewardAt.After_150_spin );
        }
        else if ( CrateItemsDatabase.spinCount == 199 )
        {
            //Debug.LogError( "200 Called" );
            GetItem( Item.GuranteedRewardAt.After_200_spin );
        }
        else if ( CrateItemsDatabase.spinCount == 249 )
        {
            //Debug.LogError( "250 Called" );
            GetItem( Item.GuranteedRewardAt.After_250_spin );
        }
        else
        {
            RandomItem( LuckFactor );
        }
    }

    /// <summary>
    /// This will return guranteed item reward
    /// </summary>
    private void GetItem( Item.GuranteedRewardAt granteedRewardAt )
    {
        CrateItemsDatabase.spinCount++;

        Computational.instance.PlayerDataObjectHere.LuckFactor += CrateItemsDatabase.instance.crate.LuckFactorIncreaseAfterEachSpin;
        //Debug.LogError( granteedRewardAt.ToString() );
        Item reward = null;
        Item[] item = CrateItemsDatabase.instance.crate.itemsCrateHas.ToArray();
        for ( int i = 0 ; i < item.Length ; i++ )
        {
            if ( item[i].guranteedRewardAt == granteedRewardAt && item[i].isGuranteedReward == true )
            {
                reward = item[i];
            }
        }
        if ( reward == null )
        {
            Debug.LogError( "Null List" );
            RandomItem( false );
        }
        else
        {
            _itemName.text = reward.itemName;
            Item.Rarity rare = reward.rarity;

            if ( rare == Item.Rarity.Common ) Computational.instance.PlayerDataObjectHere.CommonItemsCount++;
            if ( rare == Item.Rarity.Uncommon ) Computational.instance.PlayerDataObjectHere.UncommonItemsCount++;
            if ( rare == Item.Rarity.Rare ) Computational.instance.PlayerDataObjectHere.RareItemsCount++;
            if ( rare == Item.Rarity.Legendary ) Computational.instance.PlayerDataObjectHere.LegendaryItemsCount++;
            if ( rare == Item.Rarity.Mythic ) Computational.instance.PlayerDataObjectHere.MythicItemsCount++;
            //Debug.LogWarning( reward + "  " );
            _scrollCount.text = CrateItemsDatabase.spinCount.ToString();
        }
    }

    /// <summary>
    /// This will return random item based on luck factor( If luck is 100 then,
    /// it will call change odd function otherwise normal )
    /// </summary>
    private void RandomItem( bool LuckFactor )
    {
        //Debug.LogError( "Luck : " + LuckFactor );
        CrateItemsDatabase.spinCount++;
        Computational.instance.PlayerDataObjectHere.LuckFactor += CrateItemsDatabase.instance.crate.LuckFactorIncreaseAfterEachSpin;
        CrateItemsDatabase.instance.ChangeOdds( CrateItemsDatabase.spinCount, LuckFactor );

        //Item popup karie tyare ahiya random nay generate karvanu generation finalareward vala ma karvanu
        Item item = CrateItemsDatabase.GetFinalRewardItem( CrateItemsDatabase.GetItemListOfThatItemType( CrateItemsDatabase.GetRarity() ) );
        _itemName.text = item.itemName;
        //Debug.LogWarning( _itemName.text );
        _scrollCount.text = CrateItemsDatabase.spinCount.ToString();

        Item.Rarity rare = item.rarity;

        if ( rare == Item.Rarity.Common ) Computational.instance.PlayerDataObjectHere.CommonItemsCount++;
        if ( rare == Item.Rarity.Uncommon ) Computational.instance.PlayerDataObjectHere.UncommonItemsCount++;
        if ( rare == Item.Rarity.Rare ) Computational.instance.PlayerDataObjectHere.RareItemsCount++;
        if ( rare == Item.Rarity.Legendary ) Computational.instance.PlayerDataObjectHere.LegendaryItemsCount++;
        if ( rare == Item.Rarity.Mythic ) Computational.instance.PlayerDataObjectHere.MythicItemsCount++;

        GameObject resultItemPrefabGameObject = GameObject.Find( _itemName.text );
        //Debug.LogWarning(resultItemPrefabGameObject.name + "");
        resultItemPrefabGameObject.transform.GetChild( 0 ).GetComponent<Image>().color = Color.red;

        Computational.instance.ResetCrateOdds();
    }


    /// <summary>
    /// Perform single spin 
    /// </summary>
    public void SingleSpin()
    {
        // if(PLayerCurrentLevelChange == true && newPlayerCurremtLevel modulo% 25 == 1)
        // {
        //      Create function which changes odds based on the player level and put it here
                Computational.instance.ChangeOddsBasedOnPlayerCurrentLevel( Computational.instance.PlayerDataObjectHere.PlayerCurrentLevel );
        // }

        Computational.instance.PlayerDataObjectHere.CrateOpeningStyle = PlayerData.OpeningType.Single_Open;
        bool isLuck = false;
        Computational.instance.PlayerDataObjectHere.CoinSpend += CrateItemsDatabase.instance.crate.CrateOpenCost;
        _coinSpent.text = Computational.instance.PlayerDataObjectHere.CoinSpend.ToString();

        if ( Computational.instance.PlayerDataObjectHere.LuckFactor >= 100f )
        {
            isLuck = true;
        }

        if ( Computational.instance.PlayerDataObjectHere.CoinSpend >= Computational.instance.PlayerDataObjectHere.CoinSpendLimitToChangeOddsForPlayer )
        {
            Debug.LogError( "If Called of Single Spin" );
            ItemOddsComputation.instance.ChangeItemOdds( CrateItemsDatabase.GetCrateItemList() );
            ItemOddsComputation.instance.PrintAllItemOdds();
        }

        GetItemName( isLuck );

    }


    /// <summary>
    /// Perform 10 spins at once
    /// </summary>
    public void TenSpin()
    {
        // player ni pase je te item type ni item ketli chhe ena mate if(playerhasitem < thresholditem) then 

        Computational.instance.PlayerDataObjectHere.CrateOpeningStyle = PlayerData.OpeningType.Bulk_Open;
        bool isLuck = false;
        for ( int i = 0 ; i < 10 ; i++ )
        {
            Computational.instance.PlayerDataObjectHere.CoinSpend += CrateItemsDatabase.instance.crate.CrateOpenCost;
            _coinSpent.text = Computational.instance.PlayerDataObjectHere.CoinSpend.ToString();

            if ( Computational.instance.PlayerDataObjectHere.LuckFactor >= 100f )
            {
                isLuck = true;
            }

            if ( Computational.instance.PlayerDataObjectHere.CoinSpend >= Computational.instance.PlayerDataObjectHere.CoinSpendLimitToChangeOddsForPlayer )
            {
                Debug.LogError( "If Called of Ten Spin" );
                ItemOddsComputation.instance.ChangeItemOdds( CrateItemsDatabase.GetCrateItemList() );
                ItemOddsComputation.instance.PrintAllItemOdds();
            }

            GetItemName( isLuck );
        }
    }
}
