using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{

    public InventorySO inventory;
    public Transform inventoryPanel;
    
    Item[] itemsInventory;


    public int updateInventory() {
        itemsInventory = inventoryPanel.GetComponentsInChildren<Item>();
        Debug.Log("itemsInventory.Length:");
        Debug.Log(itemsInventory.Length);
        int i = 0;

        // change to Inventory size in case the size of the inventory changes
        for ( i = 0; i < itemsInventory.Length; i++ ) {
            if ( inventory.objects[i] ) {
                // update image lolz
                itemsInventory[i].img = inventory.objects[i].img;
                return i;
            }
        }
        return -1;
    }
}
