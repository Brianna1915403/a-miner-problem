using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem
{
    public enum ItemType{
        Pickaxe_1,
        Pickaxe_2,
        Pickaxe_3,
        Pickaxe_4,
        TrainPart_1,
        TrainPart_2,
        TrainPart_3,
        TrainPart_4,
        Wagon,

    }

    public static int[] GetCost(ItemType itemType){
        switch(itemType){
            default:
            case ItemType.Pickaxe_1:   return new int[]{1,2,3,4,5};
            case ItemType.Pickaxe_2:   return new int[]{6,7,8,9,10};
            case ItemType.Pickaxe_3:   return new int[]{11,12,13,14,15};
            case ItemType.Pickaxe_4:   return new int[]{16,17,18,19,20};
            case ItemType.TrainPart_1: return new int[]{1,2,3,4,5};
            case ItemType.TrainPart_2: return new int[]{6,7,8,9,10};
            case ItemType.TrainPart_3: return new int[]{11,12,13,14,15};
            case ItemType.TrainPart_4: return new int[]{16,17,18,19,20};
            case ItemType.Wagon:     return new int[]{500,550,555,600,700};
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
