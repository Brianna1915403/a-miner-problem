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
    public ActivateTrainPart train;
    public GameObject roof;
    public GameObject wheels;
    public GameObject engineCar;
    public GameObject connectingRods;
    public GameObject wheelsupport;
    public GameObject chimney;
    public GameObject tracks;
    public GameObject screws;
    public GameObject blueprint_roof;
    public GameObject blueprint_wheels;
    public GameObject blueprint_engineCar;
    public GameObject blueprint_connectingRods;
    public GameObject blueprint_wheelsupport;
    public GameObject blueprint_chimney;
    public GameObject blueprint_tracks;
    public GameObject blueprint_screws;

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
        CreateItemButton(StoreItem.ItemType.TrainPart_1, "Wheels", StoreItem.GetCost(StoreItem.ItemType.TrainPart_1), -485, 3);
        CreateItemButton(StoreItem.ItemType.TrainPart_2, "Wheel Support", StoreItem.GetCost(StoreItem.ItemType.TrainPart_2), -485, 4);
        CreateItemButton(StoreItem.ItemType.TrainPart_3, "Connecting Rods", StoreItem.GetCost(StoreItem.ItemType.TrainPart_3), -485, 5);
        CreateItemButton(StoreItem.ItemType.TrainPart_4, "Engine Car", StoreItem.GetCost(StoreItem.ItemType.TrainPart_4), -485, 6);
        CreateItemButton(StoreItem.ItemType.TrainPart_5, "Roof", StoreItem.GetCost(StoreItem.ItemType.TrainPart_5), -485, 7);
        CreateItemButton(StoreItem.ItemType.TrainPart_6, "Chimney", StoreItem.GetCost(StoreItem.ItemType.TrainPart_6), -485, 8);
        CreateItemButton(StoreItem.ItemType.TrainPart_7, "Screws", StoreItem.GetCost(StoreItem.ItemType.TrainPart_7), -485, 9);
        CreateItemButton(StoreItem.ItemType.TrainPart_8, "Tracks", StoreItem.GetCost(StoreItem.ItemType.TrainPart_8), -485, 10);
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
        switch(itemType){
            default:
            case StoreItem.ItemType.Pickaxe_1:
            {
                Debug.Log("Pickaxe_1 has been bought");
                break;
            }
            case StoreItem.ItemType.Pickaxe_2:
            {
                Debug.Log("Pickaxe_2 has been bought");
                break;
            }
            case StoreItem.ItemType.Pickaxe_3:
            {
                Debug.Log("Pickaxe_3 has been bought");
                break;
            }
            case StoreItem.ItemType.Pickaxe_4:
            {
                Debug.Log("Pickaxe_4 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_1:
            {
                train.activate(wheels);
                train.deactivate(blueprint_wheels);
                Debug.Log("TrainPart_1 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_2:
            {
                train.activate(wheelsupport);
                train.deactivate(blueprint_wheelsupport);
                Debug.Log("wheelsupport has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_3:
            {
                train.activate(connectingRods);
                train.deactivate(blueprint_connectingRods);
                Debug.Log("Pickaxe_3 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_4:
            {
                train.activate(engineCar);
                train.deactivate(blueprint_engineCar);
                Debug.Log("TrainPart_4 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_5:
            {
                train.activate(roof);
                train.deactivate(blueprint_roof);
                Debug.Log("TrainPart_5 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_6:
            {
                train.activate(chimney);
                train.deactivate(blueprint_chimney);
                Debug.Log("TrainPart_6 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_7:
            {
                train.activate(screws);
                train.deactivate(blueprint_screws);
                Debug.Log("TrainPart_7 has been bought");
                break;
            }
            case StoreItem.ItemType.TrainPart_8:
            {
                train.activate(tracks);
                train.deactivate(blueprint_tracks);
                Debug.Log("TrainPart_8 has been bought");
                break;
            }
        }
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
