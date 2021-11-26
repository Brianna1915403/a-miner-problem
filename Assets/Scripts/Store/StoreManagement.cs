using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManagement : MonoBehaviour
{
    private RectTransform container;
    [SerializeField] private GameObject shopItemTemplate;
    private IShopCustomer shopCustomer = new StoreInteraction();
    
    private void Awake(){
        container = transform.Find("Container").gameObject.GetComponent<RectTransform>();
        shopItemTemplate = GameObject.FindGameObjectWithTag("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }

    private void Start() {
        Debug.Log("Coordinates of shop item panel: "+shopItemTemplate.transform.position);
        CreateItemButton(StoreItem.ItemType.Pickaxe_1, "Pickaxe_1", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_1), 0, 1);
        CreateItemButton(StoreItem.ItemType.Pickaxe_2, "Pickaxe_2", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_2), 0, 2);
        CreateItemButton(StoreItem.ItemType.Pickaxe_3, "Pickaxe_3", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_3), 0, 3);
        CreateItemButton(StoreItem.ItemType.Pickaxe_4, "Pickaxe_4", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_4), 0, 4);
        CreateItemButton(StoreItem.ItemType.TrainPart_1, "TrainPart_1", StoreItem.GetCost(StoreItem.ItemType.TrainPart_1), -485, 1);
        CreateItemButton(StoreItem.ItemType.TrainPart_2, "TrainPart_2", StoreItem.GetCost(StoreItem.ItemType.TrainPart_2), -485, 2);
        CreateItemButton(StoreItem.ItemType.TrainPart_3, "TrainPart_3", StoreItem.GetCost(StoreItem.ItemType.TrainPart_3), -485, 3);
        CreateItemButton(StoreItem.ItemType.TrainPart_4, "TrainPart_4", StoreItem.GetCost(StoreItem.ItemType.TrainPart_4), -485, 4);
        CreateItemButton(StoreItem.ItemType.Wagon, "Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), -485, 7);

        Hide();
    }

    private void CreateItemButton(StoreItem.ItemType itemType, string itemName, List<int> itemCost, int xPositionIndex, int yPositionIndex){
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

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyItem(itemCost, itemType));
    }

    void TryBuyItem(List<int> itemCost, StoreItem.ItemType itemType){
        List<int> x = new List<int>() {1,2,3,4,5};
        Debug.Log(itemType);
        Debug.Log(shopCustomer.TrySpendOreAmount(x));
        if(shopCustomer.TrySpendOreAmount(x)){
            // can afford cost
            shopCustomer.BoughtItem(itemType);
        }
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
