using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(StoreItem.ItemType itemType);
    bool TrySpendOreAmount(int[] oreAmount);
}
