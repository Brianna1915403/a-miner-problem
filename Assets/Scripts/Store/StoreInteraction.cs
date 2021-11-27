using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInteraction : MonoBehaviour, IShopCustomer
{

    public void BoughtItem(StoreItem.ItemType itemType)
    {
        throw new System.NotImplementedException();
    }

    public bool TrySpendOreAmount(List<int> oreAmountRequired)
    {
        // Debug.Log(oreName);
        // Debug.Log(oreCount);

        // for(int i = 0; i < 5; i++){
        //     if(oreAmountRequired[i] > oreCount[i]){
        //         return false;
        //     }else{
        //         oreCount[i] -= oreAmountRequired[i];
        //     }
        // }

        return true;
    }
}
