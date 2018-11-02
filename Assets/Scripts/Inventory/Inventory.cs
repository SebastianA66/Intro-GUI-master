using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>(); //List of items
    public static bool showInv; // Show or hide inventory
    public Item selectedItem; // the item we are interacting with
    public static int money; // how much mons we have

    public Vector2 scr = Vector2.zero; // 16:9
    public Vector2 scrollPos = Vector2.zero; // Scroll bar position

    public string sortType = "All";
    #endregion

    void Start()
    {
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(401));
        

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PauseMenu.paused)
            {
                ToggleInv();
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (showInv)
            {
                inv.Add(ItemData.CreateItem(0));
                inv.Add(ItemData.CreateItem(2));
                inv.Add(ItemData.CreateItem(102));
                inv.Add(ItemData.CreateItem(201));
                inv.Add(ItemData.CreateItem(202));
                inv.Add(ItemData.CreateItem(301));
                inv.Add(ItemData.CreateItem(401));
                

            }
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return (true);
        }
    }
    private void OnGUI()
    {
        if (!PauseMenu.paused) // Only display if not paused
        {
            if (showInv) // and it toggled on
            {
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = "All";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Consumables"))
                {
                    sortType = "Consumable";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Craftable"))
                {
                    sortType = "Craftable";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Weapon"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Misc"))
                {
                    sortType = "Misc";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Quest"))
                {
                    sortType = "Quest";
                }

                DisplayInv(sortType);

                if (selectedItem != null)
                {
                    GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
                    if (selectedItem.Type != ItemTypes.Quest)
                    {
                        if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                        {
                            // Spawn item on ground
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            return;
                        }
                    }

                    switch (selectedItem.Type)
                    {
                        case ItemTypes.Consumables:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\nHeal:" + selectedItem.Heal);

                            if (CharacterHandler.curHealth < CharacterHandler.maxHealth)
                            {
                                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                                {
                                    if(selectedItem.Amount > 1)
                                    {
                                        selectedItem.Amount--;
                                    }
                                    else
                                    {
                                        inv.Remove(selectedItem);
                                        selectedItem = null;
                                    }
                                }
                            }

                            break;
                        case ItemTypes.Craftable:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value);

                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                            {

                            }
                            break;
                        case ItemTypes.Armour:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\nArmour:" + selectedItem.Armour);

                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Wear"))
                            {

                            }
                            break;
                        case ItemTypes.Weapon:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\nDamage:" + selectedItem.Damage);

                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                            {

                            }
                            break;
                        case ItemTypes.Misc:

                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                            {

                            }
                            break;
                        case ItemTypes.Quest:

                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                            {

                            }
                            break;
                    }

                }
            }
        }
    }
    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0; // amount of that type
            int s = 0; // slot position of ui item
            for (int i = 0; i < inv.Count; i++) // loop throw all items
            {
                if (inv[i].Type == type) // find our type
                {
                    a++; // increase ammount of this type
                }
            }
            if (a <= 35) // if the amount of this type is less than 35
            {
                for (int i = 0; i < inv.Count; i++) // we filter through all items
                {
                    if(inv[i].Type == type) // if it is of type
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + a * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name)) // We display a button that is of this type and slot it under the last using s as our height
                        {
                            selectedItem = inv[i]; // This button is our selected item from our inventory

                        }
                        s++; // Once added increase our s
                        // Each new thing goes under the last
                    }
                    
                }

            }

            else // We have more than 35 in this type
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.75f * scr.y), scrollPos, new Rect(0, 0, 0, 8.75f * scr.y + ((a - 36) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area

                for(int i = 0; i < inv.Count; i++) // Loop throw all items
                {
                    if(inv[i].Type == type) // If it is of type
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0 * scr.y + a * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name)) // We display a button that is of this type and slot it under the last using s as our height
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }

                #endregion
                GUI.EndScrollView();
            }

        }
        else
        {

            #region Non Scroll Inventory
            if (inv.Count <= 35)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i]; // If this item is selected set it to the selected item
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            #endregion
            #region Scroll Inventory
            else // We are greater than 35
            {
                // Our moved pos in scrolling  // Our view window     // Our current position in the scrolling
                scrollPos = GUI.BeginScrollView(new Rect(0, 0, 6 * scr.x, 9 * scr.y), scrollPos, new Rect(0, 0, 0, 8.75f * scr.y + ((inv.Count - 35) * (0.25f * scr.y))), false, true); // The viewable area and can we see the horizontal and vertical bar
                                                                                                                                                                                        // Show GUI button on the screen for each item
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i]; // If this item is selected set it to the selected item
                        Debug.Log(selectedItem.Name);
                    }
                }
                // The end of our viewing area
                GUI.EndScrollView();
                #endregion
            }
        }       

    }
}
