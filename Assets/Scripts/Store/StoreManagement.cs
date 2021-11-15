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
        //CreateItemButton("Pickaxe", StoreItem.GetCost(StoreItem.ItemType.Pickaxe), 0);
        CreateItemButton("TrainPart", StoreItem.GetCost(StoreItem.ItemType.TrainPart), 1);
        CreateItemButton("Wagon", StoreItem.GetCost(StoreItem.ItemType.Wagon), 2);
    }

    private void CreateItemButton(string itemName, int[] itemCost, int positionIndex){
        GameObject shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float spacing = -50f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, spacing * positionIndex);

        Transform text = shopItemTransform.transform.GetChild(1);

        text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemName);

        Debug.Log(itemCost[1]);

        for (int i = 1; i < text.childCount; i++){
            text.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(itemCost[i-1].ToString());
        }

        //shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }
}
