using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{

    public InventorySO inventory;
    
    private Item[] itemsInventory;

    private Item heldItem;
    private bool playerHoldingItem;

    void Start() {
        itemsInventory = GetComponentsInChildren<Item>();
        inventory.clearInventory();
        updateInventory();
    }

    public int updateInventory() {
        int i = 0;

        // change to Inventory size in case the size of the inventory changes
        for ( i = 0; i < itemsInventory.Length; i++ ) {
            if ( inventory.objects[i] ) {
                // update image lolz
                itemsInventory[i].spriteObject = inventory.objects[i].img;
                itemsInventory[i].updateImage();
            }
        }
        return 1;
    }
}
