using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int ItemID)
    {
        string name = "";
        int id = 0;
        string description = "";
        int value = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;
        int heal = 0;
        string icon = "";
        string mesh = "";
        ItemTypes type = ItemTypes.Armour;

        switch(ItemID)
        {
            #region Consumables 0-99
            
            case 0:
                name = "Apple";
                description = "Munchies and Crunchies";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "Apple_Icon";
                mesh = "Apple_Mesh";
                type = ItemTypes.Consumables;
                break;

            case 1:
                name = "Chicken";
                description = "Mysterious wall chicken";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 40;
                icon = "Chicken_Icon";
                mesh = "Chicken_Mesh";
                type = ItemTypes.Consumables;
                break;

            case 2:
                name = "Meat";
                description = "Cooked to perfection";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 50;
                icon = "Meat_Icon";
                mesh = "Mean_Mesh";
                type = ItemTypes.Consumables;
                break;
            #endregion

            #region Armour 100-199

            case 100:
                name = "Wooden Helmet";
                description = "Doesn't seem very sturdy";
                value = 5;
                damage = 0;
                armour = 10;
                amount = 1;
                heal = 0;
                icon = "WoodenHelmet_Icon";
                mesh = "WoodenHelmet_Mesh";
                type = ItemTypes.Armour;
                break;

            case 101:
                name = "Leather Helmet";
                description = "Made from the hide of certain animals";
                value = 5;
                damage = 0;
                armour = 15;
                amount = 1;
                heal = 0;
                icon = "LeatherHelmet_Icon";
                mesh = "LeatherHelmet_Mesh";
                type = ItemTypes.Armour;
                break;

            case 102:
                name = "Iron Helmet";
                description = "IRONic";
                value = 5;
                damage = 0;
                armour = 20;
                amount = 1;
                heal = 0;
                icon = "IronHelmet_Icon";
                mesh = "IronHelmet_Mesh";
                type = ItemTypes.Armour;
                break;
            #endregion

            #region Weapons 200-299
            case 200:
                name = "Wooden Sword";
                description = "Watch out for splinters";
                value = 5;
                damage = 10;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "WoodenSword_Icon";
                mesh = "WoodenSword_Mesh";
                type = ItemTypes.Weapon;
                break;

            case 201:
                name = "Zweihandler";
                description = "Well, What is it?";
                value = 20;
                damage = 35;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Zweihandler_Icon";
                mesh = "Zweihandler_Mesh";
                type = ItemTypes.Weapon;
                break;

            case 202:
                name = "Poleaxe";
                description = "The most versatile weapon ever created";
                value = 25;
                damage = 40;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Poleaxe_Icon";
                mesh = "Poleaxe_Mesh";
                type = ItemTypes.Weapon;
                break;

            #endregion

            #region Crafting 300-399
            case 300:
                name = "Branch";
                description = "A sturdy tree branch";
                value = 2;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Branch_Icon";
                mesh = "Branch_Mesh";
                type = ItemTypes.Craftable;
                break;

            case 301:
                name = "Iron ingot";
                description = "Used for crafting iron weapons and armour";
                value = 4;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "IronIngot_Icon";
                mesh = "IronIngot_Mesh";
                type = ItemTypes.Craftable;
                break;

            case 302:
                name = "Bronze ingot";
                description = "Used for crafting bronze weapons and armour";
                value = 3;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "BronzeIngot_Icon";
                mesh = "BronzeIngot_Mesh";
                type = ItemTypes.Craftable;
                break;
            #endregion

            #region Misc 400-499
            case 400:
                name = "Sand";
                description = "It's course, rough, iritating and it gets everywhere";
                value = 1;
                damage = 0;
                armour = 0;
                amount = 5;
                heal = 0;
                icon = "Sand_Icon";
                mesh = "Sand_Mesh";
                type = ItemTypes.Quest;
                break;

            case 401:
                name = "Ring of Favour and Protection";
                description = "Strength, Health, Endurance. Everything you could ever want";
                value = 50;
                damage = 10;
                armour = 10;
                amount = 1;
                heal = 10;
                icon = "RingOfFavourAndProtection_Icon";
                mesh = "RingOfFavourAndProtection_Mesh";
                type = ItemTypes.Quest;
                break;

            case 402:
                name = "Apple0";
                description = "Munchies and Crunchies";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "Apple0_Icon";
                mesh = "Apple0_Mesh";
                type = ItemTypes.Consumables;
                break;
                #endregion
        }

        Item temp = new Item
        {
            Name = name,
            Description = description,
            Id = ItemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Icon = Resources.Load("Icons/" + icon) as Texture2D,
            MeshName = mesh
        };
        return temp;

      
    }
}

