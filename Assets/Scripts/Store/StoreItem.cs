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
        TrainPart_5,
        TrainPart_6,
        TrainPart_7,
        TrainPart_8,
        Wagon,

    }

    public static List<int> GetCost(ItemType itemType){
        switch(itemType){
            default:
            case ItemType.Pickaxe_1:   return CreateList(1,0,0,0,0);
            case ItemType.Pickaxe_2:   return CreateList(1,2,3,4,5);
            case ItemType.Pickaxe_3:   return CreateList(1,2,3,4,5);
            case ItemType.Pickaxe_4:   return CreateList(1,2,3,4,5);
            case ItemType.TrainPart_1: return CreateList(2,0,0,1,1);
            case ItemType.TrainPart_2: return CreateList(1,2,3,4,5);
            case ItemType.TrainPart_3: return CreateList(1,2,3,4,5);
            case ItemType.TrainPart_4: return CreateList(1,2,3,4,5);
            case ItemType.TrainPart_5: return CreateList(1, 2, 3, 4, 5);
            case ItemType.TrainPart_6: return CreateList(1, 2, 3, 4, 5);
            case ItemType.TrainPart_7: return CreateList(1, 2, 3, 4, 5);
            case ItemType.TrainPart_8: return CreateList(1, 2, 3, 4, 5);
            case ItemType.Wagon:       return CreateList(1,2,3,4,5);
        }
    }

    public static List<T> CreateList<T>(params T[] values){
        return new List<T>(values);
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
