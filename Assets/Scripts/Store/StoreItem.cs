using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem
{
    public enum ItemType{
        Pickaxe,
        TrainPart,
        Wagon
    }

    public static int[] GetCost(ItemType itemType){
        switch(itemType){
            default:
            case ItemType.Pickaxe:   return new int[]{1,2,3,4,5};
            case ItemType.TrainPart: return new int[]{6,7,8,9,10};
            case ItemType.Wagon:     return new int[]{111,112,113,114,115};
        }
    }

    // public static Sprite GetSprite(ItemType itemType){
    //     switch (itemType)
    //     {
    //         default:
    //         case ItemType.Pickaxe:   return GameAssets.i.s_Pickaxe;
    //         case ItemType.TrainPart: return GameAssets.i.s_TrainPart;
    //         case ItemType.Wagon:     return GameAssets.i.s_Wagon;
    //     }
    // }
}
