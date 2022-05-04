using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computational : MonoBehaviour
{
    public PlayerData PlayerDataObjectHere;
    public static Computational instance;

    public int baseOddCommon = 0;
    public int baseOddUnommon = 0;
    public int baseOddRare = 0;
    public int baseOddLegendary = 0;
    public int baseOddMythic = 0;

    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy( gameObject );
        }
    }

    private void Start()
    {
        if ( Computational.instance.PlayerDataObjectHere.BattlePassPurchased == true )
        {
            BaseOddsForBattlepassPurchased();
        }




    }

    /// <summary>
    /// Reset itemtypes odds to its starting value because scriptable object doesn't reset automatically when restart
    /// </summary>

    public void ResetCrateOdds()
    {
        Debug.LogError( "ResetCrateOdds() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = baseOddCommon;
        CrateItemsDatabase.instance.crate.uncommonItemOdds = baseOddUnommon;
        CrateItemsDatabase.instance.crate.rareItemOdds = baseOddRare;
        CrateItemsDatabase.instance.crate.legendaryItemOdds = baseOddLegendary;
        CrateItemsDatabase.instance.crate.mythicItemOdds = baseOddMythic;
    }

    public static void TakeOdds()
    {
        Debug.LogError( "TakeOdds() Called" );
        instance.baseOddCommon = CrateItemsDatabase.instance.crate.commonItemOdds;
        instance.baseOddUnommon = CrateItemsDatabase.instance.crate.uncommonItemOdds;
        instance.baseOddRare = CrateItemsDatabase.instance.crate.rareItemOdds;
        instance.baseOddLegendary = CrateItemsDatabase.instance.crate.legendaryItemOdds;
        instance.baseOddMythic = CrateItemsDatabase.instance.crate.mythicItemOdds;
    }

    /// <summary>
    /// Change Odds for item type when luck factor of player is 100%
    /// </summary>

    public void ChangeOddsForLuck()
    {
        Debug.LogError( "ChangeOddsForLuck() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( baseOddCommon * 0f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( baseOddUnommon * 0f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( baseOddRare * 1f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( baseOddLegendary * 0.5f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( baseOddMythic * 0f );
    }


    /// <summary>
    /// Change Odds for item type before 100 spin counts
    /// </summary>
    public void ChangeOddsForFirst100()
    {
        Debug.LogError( "ChangeOddsForFirst100() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( baseOddCommon * 1f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( baseOddUnommon * 1f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( baseOddRare * 1f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( baseOddLegendary * 0f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( baseOddMythic * 0f );
    }

    /// <summary>
    /// Change Odds for item type after 100 spin counts
    /// </summary>
    public void ChangeOddsAfter100()
    {
        Debug.LogError( "ChangeOddsAfter100() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( baseOddCommon * 1f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( baseOddUnommon * 1f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( baseOddRare * 1f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( baseOddLegendary * 0.3f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( baseOddMythic * 0f );
    }

    /// <summary>
    /// Change Odds for item type after 150 spin counts
    /// </summary>
    public void ChangeOddsAfter150()
    {
        Debug.LogError( "ChangeOddsAfter150() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( baseOddCommon * 0.8f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( baseOddUnommon * 0.8f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( baseOddRare * 1f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( baseOddLegendary * 0.8f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( baseOddMythic * 0f );
    }

    /// <summary>
    /// Change Odds for item type after 200 spin counts
    /// </summary>
    public void ChangeOddsAfter200()
    {
        Debug.LogError( "ChangeOddsAfter200() Called" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( baseOddCommon * 0.5f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( baseOddUnommon * 0.5f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( baseOddRare * 0.8f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( baseOddLegendary * 1f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( baseOddMythic * 1f );
    }

    /// <summary>
    /// Reset odds for battlepass purchased player
    /// </summary>
    private void BaseOddsForBattlepassPurchased()
    {
        Debug.LogError( "Called BP" );
        CrateItemsDatabase.instance.crate.commonItemOdds = (int)( CrateItemsDatabase.instance.crate.commonItemOdds * 1.0f );
        CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( CrateItemsDatabase.instance.crate.uncommonItemOdds * 1.0f );
        CrateItemsDatabase.instance.crate.rareItemOdds = (int)( CrateItemsDatabase.instance.crate.rareItemOdds * 0.8f );
        CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( CrateItemsDatabase.instance.crate.legendaryItemOdds * 0.8f );
        CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( CrateItemsDatabase.instance.crate.mythicItemOdds * 0.8f );
        instance.PlayerDataObjectHere.BattlePassPurchased = false;
    }

    /// <summary>
    /// Debug print for crate odds at present
    /// </summary>
    public void PrintDebugForAllCurrentCrateOdds()
    {
        Debug.LogWarning( "Common : " + CrateItemsDatabase.instance.crate.commonItemOdds );
        Debug.LogWarning( "Uncommon : " + CrateItemsDatabase.instance.crate.uncommonItemOdds );
        Debug.LogWarning( "Rare : " + CrateItemsDatabase.instance.crate.rareItemOdds );
        Debug.LogWarning( "Legendary : " + CrateItemsDatabase.instance.crate.legendaryItemOdds );
        Debug.LogWarning( "Mythic : " + CrateItemsDatabase.instance.crate.mythicItemOdds );
    }

    public void ChangeOddsBasedOnPlayerCurrentLevel(int playerLevel)
    {
        if(playerLevel <= 25)
        {
            Debug.LogError( "< 25 Level valu called" );
            CrateItemsDatabase.instance.crate.commonItemOdds = (int)( CrateItemsDatabase.instance.crate.commonItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( CrateItemsDatabase.instance.crate.uncommonItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.rareItemOdds = (int)( CrateItemsDatabase.instance.crate.rareItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( CrateItemsDatabase.instance.crate.legendaryItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( CrateItemsDatabase.instance.crate.mythicItemOdds * 1.0f );
        }
        else if ( playerLevel <= 50 )
        {
            Debug.LogError( " < 50 Level valu called" );
            CrateItemsDatabase.instance.crate.commonItemOdds = (int)( CrateItemsDatabase.instance.crate.commonItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.uncommonItemOdds = (int)( CrateItemsDatabase.instance.crate.uncommonItemOdds * 1.0f );
            CrateItemsDatabase.instance.crate.rareItemOdds = (int)( CrateItemsDatabase.instance.crate.rareItemOdds * 1f );
            CrateItemsDatabase.instance.crate.legendaryItemOdds = (int)( CrateItemsDatabase.instance.crate.legendaryItemOdds * 1f );
            CrateItemsDatabase.instance.crate.mythicItemOdds = (int)( CrateItemsDatabase.instance.crate.mythicItemOdds * 0.98f );
        }
        else if ( playerLevel <= 75 )
        {
            Debug.LogError( " < 75 Level valu called" );
        }
        else
        {
            Debug.LogError( "1d00 valu means aekay vagar nu" );
        }    

    }

}
