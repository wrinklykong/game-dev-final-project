using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollisions : MonoBehaviour
{

    public InventorySO inventory;
    public InventoryPanel panel;

    public void OnTriggerEnter2D(Collider2D other) {
        if ( other.tag == "item" ) {
            Debug.Log("Item touched!");
            ItemSO itemTouched = other.gameObject.GetComponent<Container>().item;
            Debug.Log(itemTouched);
            if (itemTouched) {
                inventory.addItem(itemTouched);
                panel.updateInventory();
                Destroy(other.gameObject);
            }
            else {
                Debug.Log("ERROR: NO item found :,(");
            }
        }
    }
}