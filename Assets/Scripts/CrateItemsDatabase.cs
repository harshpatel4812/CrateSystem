using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CrateItemsDatabase  : MonoBehaviour 
{

#region Declaration

    public Dictionary<Item.Rarity, int> itemWithOdd  = new Dictionary<Item.Rarity, int>();
    private Dictionary<Item.Rarity, int> itemWithOddDesc  = new Dictionary<Item.Rarity, int>();
    private Item finalItem;
    private Item.Rarity itemType;
    private int total;
    public CratesWithItems crate;
    public  static CrateItemsDatabase instance;

    [Tooltip ("Spincount manage here")]
    public static int spinCount = 0; //juna spin count ahiya thi get karavi levana and amuk time pachi reset to 0 kari devanu

#endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
  

    /// <summary>
    /// This will return List of item that Crate has
    /// </summary>
    public static List<Item> GetCrateItemList()
    {
        //Debug.LogError( "GetItemList Called" );
        List<Item> a = instance.crate.itemsCrateHas;
        foreach ( Item item in a )
        {
            //Debug.Log( item.itemName );
            item.minusAfterEachSpin = ( item.BaseOdds - item.RareOdds ) / item.ChangeToRareOddsAfterThisNumberOfSpin;
            //Debug.LogError( item.minusAfterEachSpin );
        }
        return a;//instance.crate.itemsCrateHas;
    }

    /// <Summary>
    /// Save data in Dictionary
    /// </Summary>
    private static void GetDataInDict()
    {
        instance.itemWithOdd.Add(Item.Rarity.Common, instance.crate.commonItemOdds);
        instance.itemWithOdd.Add(Item.Rarity.Uncommon, instance.crate.uncommonItemOdds);
        instance.itemWithOdd.Add( Item.Rarity.Rare, instance.crate.rareItemOdds);
        instance.itemWithOdd.Add(Item.Rarity.Legendary, instance.crate.legendaryItemOdds);
        instance.itemWithOdd.Add( Item.Rarity.Mythic, instance.crate.mythicItemOdds);

        instance.itemWithOdd = instance.itemWithOdd.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        //Check karva descending ma chhe k ny
        /* foreach (KeyValuePair<Item.Rarity, int> author in instance.itemWithOdd)  
        {  
            Debug.Log("Key: {0}, Value: {1}" + author.Key + author.Value);
        }  */
    }

    /// <Summary>
    /// Discending order ma Dictionary no data gothvay
    /// </Summary>
    private static void GetTotalAndDiscOrder()
    {
        GetDataInDict();
        instance.itemWithOddDesc = instance.itemWithOdd = instance.itemWithOdd.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (var item in instance.itemWithOddDesc)
        {
            //Debug.Log(item.Value  + " " + item.Key ) ;
        }
        foreach(int ie in instance.itemWithOdd.Values )
        {
            instance.total += ie;
        } 
    }

    /// <Summary>
    /// Get item rarity type 
    /// </Summary>
    public static Item.Rarity GetRarity()
    {   
        GetTotalAndDiscOrder();
        //Debug.Log("Total of all odds of all item types" + instance.total);
        int randomNo = UnityEngine.Random.Range( 0, instance.total);
        //Debug.Log( "Random number for item type" + randomNo);
        for (int ii = 0; ii < instance.itemWithOddDesc.Count; ii++)
        {
            if(randomNo < instance.itemWithOddDesc.ElementAt(ii).Value)
            {
                //Debug.Log(instance.itemWithOddDesc.ElementAt(ii).Value);
                //Debug.Log(instance.itemWithOddDesc.ElementAt(ii).Key);
                instance.itemType = instance.itemWithOddDesc.ElementAt(ii).Key;
                break;
                //Debug.Log(randomNo);
            }
            else
            {
                randomNo -= instance.itemWithOddDesc.ElementAt(ii).Value;
            }
        }
        Debug.LogWarning(instance.itemType);
        return instance.itemType;
    }

    /// <summary>
    /// Return List of Items of the given Item Type
    /// </summary>
    public static List<Item> GetItemListOfThatItemType(Item.Rarity rarity)
    {
        //Je type select thy hoy ae type ni badhi item nu list banse
        //Debug.Log(rarity.ToString());
        var list = new List<Item>();
        foreach(var v in instance.crate.itemsCrateHas)
        {
            if(v.rarity == rarity)
            {
                list.Add(v);
            }
        }
        foreach (var item in list)
        {
            //Debug.Log(item.itemName + " " + item.BaseOdds);
        }
        return list;
        /* var query = from item in instance.crate.itemsCrateHas where item.rarity == rarity select item;
        return query.ToList(); */
    }


    /// <summary>
    /// This function gives Final Item as reward
    /// </summary>
    public static Item GetFinalRewardItem(List<Item> itemsList)
    {
        //spinCount++;
        string a;
        //items na odds mujab descending order ma list banse
        /* foreach (var item in itemsList)
        {
            Debug.Log(item.itemName);
        } */
        var query = from item in itemsList orderby item.BaseOdds descending select item;
         foreach (var item in query)
        {
            //Debug.Log(item.BaseOdds + " $ " + item.itemName);
        } 
        int total = 0;
        foreach (Item item in query)
        {
            total += item.BaseOdds;
        }
        //Debug.Log( "Total for items: " + total);
        int randomNo = UnityEngine.Random.Range( 0, total);
       // Debug.Log( "Random number : " + randomNo);
        for (int ii = 0; ii < query.Count(); ii++)
        {
            //Debug.Log( "Outside If " + query.ElementAt(ii).odds);
            if(randomNo < query.ElementAt(ii).BaseOdds)
            {
                //Debug.Log("Inside");
                //Debug.Log(query.ElementAt(ii).odds);
                Debug.LogWarning(query.ElementAt(ii).itemName);
                a = query.ElementAt(ii).itemName;
                instance.finalItem = query.ElementAt(ii);
                break;
            }
            else
            {
                randomNo -= query.ElementAt(ii).BaseOdds;
            }
        }
        instance.itemWithOdd.Clear();
        instance.itemWithOddDesc.Clear();
        instance.total = 0;
        return instance.finalItem;
    }

    /// <summary>
    /// This function changes odds of item type of the crate based on spin
    /// This can be putted in Computational.cs Script
    /// </summary>
    public void ChangeOdds(int SpinCount, bool Luck100)
    {
        if(Luck100 == true)
        {
            Debug.LogError( "Luck100 Called and came here" );
            Computational.TakeOdds();
            Computational.instance.ChangeOddsForLuck();
            Computational.instance.PrintDebugForAllCurrentCrateOdds();
            Computational.instance.PlayerDataObjectHere.LuckFactor = 0f;
        }
        else if(SpinCount <= 100)
        {
            Debug.LogError( "Normal spin start 100" );
            Computational.TakeOdds();
            Computational.instance.ChangeOddsForFirst100();
        }
        else if ( SpinCount <= 150 && SpinCount >= 101 )
        {
            Debug.LogError( "Normal spin start 150" );
            Computational.TakeOdds();
            Computational.instance.ChangeOddsAfter100();
        }
        else if ( SpinCount <= 200 && SpinCount >= 151 )
        {
            Debug.LogError( "Normal spin start 200" );
            Computational.TakeOdds();
            Computational.instance.ChangeOddsAfter150();
        }
        else
        {
            Debug.LogError( "Normal spin start 250" );
            Computational.TakeOdds();
            Computational.instance.ChangeOddsAfter200();
        }
    }

}

