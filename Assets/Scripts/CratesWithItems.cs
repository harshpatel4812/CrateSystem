using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Crate", menuName = "Assets/Crate")]
public class CratesWithItems : ScriptableObject
{
    public string crateName;

    [Range(0, 1000)]
    public int commonItemOdds;

    [Range(0, 1000)]
    public int uncommonItemOdds;

    [Range(0, 1000)]
    public int rareItemOdds;

    [Range(0, 1000)]
    public int legendaryItemOdds;

    [Range(0, 1000)]
    public int mythicItemOdds;

    public List<Item> itemsCrateHas;
    public int CrateOpenCost;

    public int LuckFactorIncreaseAfterEachSpin;


}

