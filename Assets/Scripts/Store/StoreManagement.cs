using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManagement : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    
    private void Awake(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int[] itemCost, int positionIndex){
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        
        shopItemTransform.Find("copperPriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost[0].ToString());
        shopItemTransform.Find("silverPriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost[1].ToString());
        shopItemTransform.Find("goldPriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost[2].ToString());
        shopItemTransform.Find("electrumPriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost[3].ToString());
        shopItemTransform.Find("platinumPriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost[4].ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }
}
