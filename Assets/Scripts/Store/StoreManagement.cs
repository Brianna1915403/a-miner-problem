using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManagement : MonoBehaviour
{
    private Transform container;
    private GameObject shopItemTemplate;
    
    private void Awake(){
        container = transform.Find("Container");
        shopItemTemplate = GameObject.FindGameObjectWithTag("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }

    private void Start() {
        CreateItemButton("Pickaxe", StoreItem.GetCost(StoreItem.ItemType.Pickaxe), 0);
        CreateItemButton("TrainPart", StoreItem.GetCost(StoreItem.ItemType.TrainPart), 1);
        CreateItemButton("Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), 2);
    }

    private void CreateItemButton(string itemName, int[] itemCost, int positionIndex){
        GameObject shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        //Debug.Log(shopItemTransform.transform.Find("nameText"));

        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemName);
        
        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemCost[0].ToString());
        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemCost[1].ToString());
        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemCost[2].ToString());
        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemCost[3].ToString());
        shopItemTransform.GetComponent<TextMeshProUGUI>().SetText(itemCost[4].ToString());

        //shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }
}
