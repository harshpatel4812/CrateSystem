using UnityEngine;
using TMPro;

public class FinalRewardDisplay : MonoBehaviour
{
    [SerializeField]private GameObject panelPrefab;
    [SerializeField]private TextMeshProUGUI textMp;


    ///<Summary>
    ///Instatiate panel prefab to display the rewarded item
    ///</Summary>
    public void displayItem()
    {
        //Computational.instance.ChangeOddsAfterFirstSpin();
        Debug.LogError( "Final Reward Display Script Called Hello" );
        //omputational.instance.Start();
        //Computational.instance.PrintDebugForAllCurrentCrateOdds();
        //Destroy(panelPrefab);
        //GameObject obj = Instantiate(panelPrefab);
        //obj.transform.SetParent(this.gameObject.transform, false);
        //obj.transform.GetChild(0).GetComponent<Image>().color = Color.black;
        //obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = textMp.text;
        //Debug.LogError("Called Prefab Instantiate");
        //Debug.LogError( "Player ID : " + Computational.instance.PlayerDataObjectHere.PlayerID );
    }



}
