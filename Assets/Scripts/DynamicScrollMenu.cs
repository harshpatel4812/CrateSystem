using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicScrollMenu : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    private GameObject obj;

    private void Start()
    {
        SetGrid();
    }


    /// <summary>
    /// This will give grid of Crate items
    /// </summary>
    private void SetGrid()
    {
        List<Item> crateItemList = CrateItemsDatabase.GetCrateItemList();
        for(int i = 0; i < crateItemList.Count ; i++)
        {
            obj = Instantiate(cell);
            
            obj.transform.SetParent(this.gameObject.transform, false);
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = crateItemList[i].itemId;
            obj.name = crateItemList[i].itemName;
            obj.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
            
            //obj.tag = crateItemList[i].itemName;
            //obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = a[i].itemName;
        }
    }
    


}
