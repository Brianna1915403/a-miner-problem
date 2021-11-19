using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManagement : MonoBehaviour
{
    private RectTransform container;
    [SerializeField] private GameObject shopItemTemplate;
    
    private void Awake(){
        container = transform.Find("Container").gameObject.GetComponent<RectTransform>();
        shopItemTemplate = GameObject.FindGameObjectWithTag("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CreateItemButton("Pickaxe_2", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_2), 0, 1);
        CreateItemButton("Pickaxe_3", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_3), 0, 2);
        CreateItemButton("Pickaxe_4", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_4), 0, 3);
        CreateItemButton("TrainPart_1", StoreItem.GetCost(StoreItem.ItemType.TrainPart_1), -485, 0);
        CreateItemButton("TrainPart_2", StoreItem.GetCost(StoreItem.ItemType.TrainPart_2), -485, 1);
        CreateItemButton("TrainPart_3", StoreItem.GetCost(StoreItem.ItemType.TrainPart_3), -485, 2);
        CreateItemButton("TrainPart_4", StoreItem.GetCost(StoreItem.ItemType.TrainPart_4), -485, 3);
        CreateItemButton("Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), -485, 7);
    }

    private void CreateItemButton(string itemName, int[] itemCost, int xPositionIndex, int yPositionIndex){
        GameObject shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float spacing = -50f;
        shopItemRectTransform.anchoredPosition = new Vector2(xPositionIndex, spacing * yPositionIndex);

        Transform text = shopItemTransform.transform.GetChild(1);

        text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemName);

        Debug.Log(itemCost[1]);

        for (int i = 1; i < text.childCount; i++){
            text.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(itemCost[i-1].ToString());
        }

        //shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        
    }

    private void TryBuyItem(StoreItem.ItemType itemType){

    }
}
