using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemOddsComputation : MonoBehaviour
{
    public static ItemOddsComputation instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy( gameObject );
        }
    }



    /// <summary>
    /// Print Debug for all items odds
    /// </summary>
    public void PrintAllItemOdds()
    {
        var abc = CrateItemsDatabase.GetCrateItemList();
        foreach(Item i in abc)
        {
            //Debug.LogError( i.BaseOdds );
        }
    }

    /// <summary>
    /// chnage odds of all items
    /// </summary>
    public void ChangeItemOdds(List<Item> itemsList)
    {

        if(Computational.instance.PlayerDataObjectHere.CrateOpeningStyle == PlayerData.OpeningType.Single_Open)
        {
            foreach ( var item in itemsList )
            {
                if ( item.BaseOdds != item.RareOdds )
                {
                    //Debug.Log( "Called ChangeItemOdds() SingleOpen" );
                    int a = (int)( ( item.BaseOdds - item.RareOdds ) * 0.9f / item.ChangeToRareOddsAfterThisNumberOfSpin );
                    //Debug.Log( item.BaseOdds );
                    item.BaseOdds -= a;
                }
            }
        }
        if( Computational.instance.PlayerDataObjectHere.CrateOpeningStyle == PlayerData.OpeningType.Bulk_Open )
        {
            foreach ( var item in itemsList )
            {
                if ( item.BaseOdds != item.RareOdds )
                {
                    //Debug.Log( "Called ChangeItemOdds() bilk" );
                    int a = ( ( item.BaseOdds - item.RareOdds ) / item.ChangeToRareOddsAfterThisNumberOfSpin );
                    //Debug.Log( item.BaseOdds );
                    item.BaseOdds -= a;
                }
            }
        }





     
    }





}
