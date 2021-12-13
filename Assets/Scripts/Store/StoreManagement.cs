using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class StoreManagement : MonoBehaviour
{
    public GameObject minecart;
    public GameObject tooltipFailed;
    public GameObject tooltipSuccess;
    private float cooldownStart = 0f;
    private float cooldown = 2f;
    private RectTransform container;
    [SerializeField] private GameObject shopItemTemplate;
    private List<string> oreName;
    private List<int> oreCount;
    private ActivateTrainPart train;

    private StoreOres storeOres;

    private void Awake()
    {
        container = transform.Find("Container").gameObject.GetComponent<RectTransform>();
        shopItemTemplate = GameObject.FindGameObjectWithTag("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
        train = FindObjectOfType<ActivateTrainPart>();
        storeOres = minecart.GetComponent<StoreOres>();
        oreName = storeOres.OreName;
        oreCount = storeOres.OreCount;
    }

    private void Start()
    {
        for (int i = 0; i < storeOres.OreName.Count; i++)
        {
            oreCount[i] = (PlayerPrefs.GetInt(storeOres.OreName[i], 0));
            Debug.Log("Ore Count" + PlayerPrefs.GetInt(storeOres.OreName[i], 0) + " " + storeOres.OreName[i]);
        }
        CreateLegend();
        CreateItemButton(StoreItem.ItemType.TrainPart_5, "Roof", StoreItem.GetCost(StoreItem.ItemType.TrainPart_5), 0, 1);
        CreateItemButton(StoreItem.ItemType.TrainPart_6, "Chimney", StoreItem.GetCost(StoreItem.ItemType.TrainPart_6), 0, 2);
        CreateItemButton(StoreItem.ItemType.TrainPart_7, "Screws", StoreItem.GetCost(StoreItem.ItemType.TrainPart_7), 0, 3);
        CreateItemButton(StoreItem.ItemType.TrainPart_8, "Tracks", StoreItem.GetCost(StoreItem.ItemType.TrainPart_8), 0, 4);
        CreateItemButton(StoreItem.ItemType.TrainPart_1, "Wheels", StoreItem.GetCost(StoreItem.ItemType.TrainPart_1), -485, 1);
        CreateItemButton(StoreItem.ItemType.TrainPart_2, "Support", StoreItem.GetCost(StoreItem.ItemType.TrainPart_2), -485, 2);
        CreateItemButton(StoreItem.ItemType.TrainPart_3, "Rods", StoreItem.GetCost(StoreItem.ItemType.TrainPart_3), -485, 3);
        CreateItemButton(StoreItem.ItemType.TrainPart_4, "Engine Car", StoreItem.GetCost(StoreItem.ItemType.TrainPart_4), -485, 4);


        //CreateItemButton(StoreItem.ItemType.Wagon, "Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), -485, 7);
        storeOres = minecart.GetComponent<StoreOres>();
        tooltipFailed.SetActive(false);
        tooltipSuccess.SetActive(false);
        oreName = storeOres.OreName;
        oreCount = storeOres.OreCount;
        Hide();
    }

    private void Update()
    {
        oreName = storeOres.OreName;
        for (int i = 0; i < storeOres.OreName.Count; i++)
        {
            oreCount[i] = (PlayerPrefs.GetInt(storeOres.OreName[i], 0));
            Debug.Log("Ore Count" + PlayerPrefs.GetInt(storeOres.OreName[i], 0) + " " + storeOres.OreName[i]);
        }


        if (Time.time >= cooldownStart)
        {
            tooltipFailed.SetActive(false);
            tooltipSuccess.SetActive(false);
            cooldownStart = Time.time;
        }
    }

    public void CreateLegend()
    {
        GameObject shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float spacing = -50f;
        shopItemRectTransform.anchoredPosition = new Vector2(-485, spacing * 0);

        Transform text = shopItemTransform.transform.GetChild(1);

        text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Amount");

        for (int i = 1; i < text.childCount; i++)
        {
            text.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(oreCount[i - 1].ToString());
        }
    }

    private void CreateItemButton(StoreItem.ItemType itemType, string itemName, List<int> itemCost, int xPositionIndex, int yPositionIndex)
    {

        GameObject shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float spacing = -50f;
        shopItemRectTransform.anchoredPosition = new Vector2(xPositionIndex, spacing * yPositionIndex);

        Transform text = shopItemTransform.transform.GetChild(1);

        text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemName);

        for (int i = 1; i < text.childCount; i++)
        {
            text.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(itemCost[i - 1].ToString());
        }

        //shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyItem(itemCost, itemType));
    }

    void TryBuyItem(List<int> itemCost, StoreItem.ItemType itemType)
    {
        if (TrySpendOreAmount(itemCost))
        {
            // can afford cost
            tooltipSuccess.SetActive(true);
            cooldownStart = Time.time + cooldown;
            
            BoughtItem(itemType);
        }
    }

    public bool TrySpendOreAmount(List<int> oreAmountRequired)
    {
        for (int i = 0; i < storeOres.OreName.Count; i++)
        {
            if (oreAmountRequired[i] > oreCount[i])
            {
                tooltipFailed.SetActive(true);
                Debug.Log("tooltip active");
                cooldownStart = Time.time + cooldown;
                CreateLegend();
                return false;
            }
        }
        for (int j = 0; j < storeOres.OreName.Count; j++)
        {
            PlayerPrefs.SetInt(oreName[j], PlayerPrefs.GetInt(oreName[j], 0) - oreAmountRequired[j]);
            oreCount[j] = (PlayerPrefs.GetInt(storeOres.OreName[j], 0));
        }
        Debug.Log("Able to buy");
        CreateLegend();
        return true;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void BoughtItem(StoreItem.ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case StoreItem.ItemType.TrainPart_1:
                {
                    train.activate(train.wheels);
                    train.deactivate(train.blueprint_wheels);
                    Debug.Log("TrainPart_1 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_2:
                {
                    train.activate(train.wheelsupport);
                    train.deactivate(train.blueprint_wheelsupport);
                    Debug.Log("wheelsupport has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_3:
                {
                    train.activate(train.connectingRods);
                    train.deactivate(train.blueprint_connectingRods);
                    Debug.Log("Pickaxe_3 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_4:
                {
                    train.activate(train.engineCar);
                    train.deactivate(train.blueprint_engineCar);
                    Debug.Log("TrainPart_4 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_5:
                {
                    train.activate(train.roof);
                    train.deactivate(train.blueprint_roof);
                    Debug.Log("TrainPart_5 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_6:
                {
                    train.activate(train.chimney);
                    train.deactivate(train.blueprint_chimney);
                    Debug.Log("TrainPart_6 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_7:
                {
                    train.activate(train.screws);
                    train.deactivate(train.blueprint_screws);
                    Debug.Log("TrainPart_7 has been bought");
                    break;
                }
            case StoreItem.ItemType.TrainPart_8:
                {
                    train.activate(train.tracks);
                    train.deactivate(train.blueprint_tracks);
                    Debug.Log("TrainPart_8 has been bought");
                    break;
                }
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
