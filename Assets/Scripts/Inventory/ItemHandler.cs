using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemID = 0;
    public ItemTypes itemType;
    public int amount;
    public void OnCollection()
    {
        if(itemType == ItemTypes.Money)
        {
            Inventory.money += amount; // Add to money
        }
        else if(itemType == ItemTypes.Craftable || itemType == ItemTypes.Consumables)
        {
            int found = 0;
            int addIndex = 0;
            for (int i = 0; i < Inventory.inv.Count; i++)
            {
                if(itemID == Inventory.inv[i].Id)
                {
                    found = 1;
                    addIndex = 1;
                    break;
                }
            }
            if(found ==1)
            {
                Inventory.inv[addIndex].Amount += amount;
            }
            else
            {
                Inventory.inv.Add(ItemData.CreateItem(itemID)); // Pick up and add to inv
                if(amount > 1)
                {
                    for(int i = 0; i < Inventory.inv.Count; i++)
                    {
                        if(itemID == Inventory.inv[i].Id)
                        {
                            Inventory.inv[addIndex].Amount = amount;
                        }
                    }
                    
                }
            }
        }
        else // Weapons or armour/misc
        {
            Inventory.inv.Add(ItemData.CreateItem(itemID)); // Pick up and add to inv
        }
        DragAndDropInventory.AddItem(itemID);
        Destroy(gameObject); // Remove from world
    }

}
