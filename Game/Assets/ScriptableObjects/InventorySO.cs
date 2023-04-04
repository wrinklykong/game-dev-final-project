using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Inventory/DefaultInventory")]

public class InventorySO : ScriptableObject
{
    const int inventorySize = 12;
    public ItemSO[] objects = new ItemSO[inventorySize];

    public int clearInventory() {
        int i = 0;
        for ( i = 0; i < inventorySize; i++ ) {
            if ( removeItem(i) != i ) {
                return -1;
            }
        }
        return 1;
    }

    public int removeItem(int pos) {
        if ( objects[pos] ) {
            objects[pos] = null;
            return pos;
        }
        return -1;
    }
    
    public int addItem(ItemSO item) {
        int i = 0;
        for ( i = 0; i < inventorySize; i++ ) {
            if ( !objects[i] ) {
                objects[i] = item;
                return i;
            }
        }
        return -1;
    }

    public int addItem(ItemSO item, int pos) {
        if ( objects[pos] ) {
            return -1;
        }
        else {            
            objects[pos] = item;
            return pos;
        }
    }

}
