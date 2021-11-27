using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManagement : MonoBehaviour
{
    private RectTransform container;
    [SerializeField] private GameObject shopItemTemplate;
    private List<string> oreName;
    private List<int> oreCount;
    
    private void Awake(){
        container = transform.Find("Container").gameObject.GetComponent<RectTransform>();
        shopItemTemplate = GameObject.FindGameObjectWithTag("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);

        oreName = StoreOres.Instance.OreName;
        oreCount = StoreOres.Instance.OreCount;
    }

    private void Start() {
        CreateItemButton(StoreItem.ItemType.Pickaxe_1, "Pickaxe_1", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_1), 0, 3);
        CreateItemButton(StoreItem.ItemType.Pickaxe_2, "Pickaxe_2", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_2), 0, 4);
        CreateItemButton(StoreItem.ItemType.Pickaxe_3, "Pickaxe_3", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_3), 0, 5);
        CreateItemButton(StoreItem.ItemType.Pickaxe_4, "Pickaxe_4", StoreItem.GetCost(StoreItem.ItemType.Pickaxe_4), 0, 6);
        CreateItemButton(StoreItem.ItemType.TrainPart_1, "TrainPart_1", StoreItem.GetCost(StoreItem.ItemType.TrainPart_1), -485, 3);
        CreateItemButton(StoreItem.ItemType.TrainPart_2, "TrainPart_2", StoreItem.GetCost(StoreItem.ItemType.TrainPart_2), -485, 4);
        CreateItemButton(StoreItem.ItemType.TrainPart_3, "TrainPart_3", StoreItem.GetCost(StoreItem.ItemType.TrainPart_3), -485, 5);
        CreateItemButton(StoreItem.ItemType.TrainPart_4, "TrainPart_4", StoreItem.GetCost(StoreItem.ItemType.TrainPart_4), -485, 6);
        //CreateItemButton(StoreItem.ItemType.Wagon, "Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), -485, 7);

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
        if(TrySpendOreAmount(itemCost)){
            Debug.Log("In the if statement of TryBuyItem");
            // can afford cost
            BoughtItem(itemType);
        }
    }

    public bool TrySpendOreAmount(List<int> oreAmountRequired)
    {
        for(int i = 0; i < 5; i++){
            if(oreAmountRequired[i] > oreCount[i]){ 
                return false; 
            }
        }
        for(int j = 0; j < 5; j++){ 
            oreCount[j] -= oreAmountRequired[j]; 
        }

        return true;
    }

    public void BoughtItem(StoreItem.ItemType itemType)
    {
        Debug.Log("Item bought = " + itemType);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
