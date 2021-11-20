using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInteraction : MonoBehaviour, IShopCustomer
{
    private int[] oreAmount;

    public void BoughtItem(StoreItem.ItemType itemType)
    {
        throw new System.NotImplementedException();
    }

    public bool TrySpendOreAmount(int[] oreAmount)
    {
        bool result = false;

        for(int i = 0; i < 5; i++){
            if(!(oreAmount[i] >= oreAmount[i]) ){
                result = false;
            }
            else{
                result = true;
            }
        }

        return result;
    }
}
