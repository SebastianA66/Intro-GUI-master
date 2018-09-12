﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour {

    #region Variables
    [Header("Texture List")]

    ///Texture2D List for skin,hair, mouth, eyes

    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();

    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex;

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax, mouthMax, eyesMax, clothesMax, armourMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Adventurer";
    [Header("Stats")]
    //Base stats that affect the character
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
    //the points which we use to increase stats
    public int points = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;

    #endregion

    #region Start
    private void Start()
    {
        //in start we need to set up the following
        
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
       for(int i = 0; i < skinMax; i++)
       {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
       }
        //for loop looping from 0 to less than the max amount of hair textures we need
       for(int i = 0; i < hairMax; i++)
       {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
       }

        //for loop looping from 0 to less than the max amount of mouth textures we need 
        for(int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }


        //for loop looping from 0 to less than the max amount of eyes textures we need
        for(int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }

        for(int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(temp);
        } 

        for(int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            armour.Add(temp);
        }

        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0 );
        SetTexture("Mouth", 0 );
        SetTexture("Eyes", 0 );
        SetTexture("Armour", 0 );
        SetTexture("Clothes", 0 );
        
        #endregion
    }
    #endregion

    #region SetTexture
    
    //the string is the name of the material we are editing, the int is the direction we are changing
    //Create a function that is called SetTexture it should contain a string and int

    void SetTexture(string type, int dir)
    {

        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
        switch(type)
        {
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number is 1
                matIndex = 1;
                //break
                break;

            //now repeat for each material 
            //hair is 2
            case "Hair":
                //index is the same as our index
                index = hairIndex;
                //max is the same as our max
                max = hairMax;
                //textures is our list .ToArray()
                textures = hair.ToArray();
                //material index element number is 2
                matIndex = 2;
                //break
                break;
            //mouth is 3
            case "Mouth":
                //index is the same as our index
                index = mouthIndex;
                //max is the same as our max
                max = mouthMax;
                //textures is our list .ToArray()
                textures = mouth.ToArray();
                //material index element number is 3
                matIndex = 3;
                //break
                break;
            //eyes are 4
            case "Eyes":
                //index is the same as our index
                index = eyesIndex;
                //max is the same as our max
                max = eyesMax;
                //textures is our list .ToArray()
                textures = eyes.ToArray();
                //material index element number is 4
                matIndex = 4;
                //break
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
        }
        #endregion
        #region OutSide Switch
        //outside our switch statement
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if(index < 0)
        {
            index = max - 1;
        }
        if(index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        character.materials = mat;
        //create another switch that is goverened by the same string name of our material
        #endregion
        #region Set Material Switch
        switch(type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            //case hair
            case "Hair":
                //index equals our index
                hairIndex = index;
                //break
                break;
            //case mouth
            case "Mouth":
                //index equals our index
                mouthIndex = index;
                //break
                break;
            //case eyes
            case "Eyes":
                //index equals our index
                eyesIndex = index;
                //break
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
        }
        #endregion
    }

    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void Save()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);

        //SetString CharacterName
        PlayerPrefs.SetString("CharacterIndex", charName);
    }

    #endregion

    #region OnGUI
    private void OnGUI() //Function for our GUI elements
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        //create an int that will help with shuffling your GUI elements under eachother
        int i = 0;
        #region Skin
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f*scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Skin", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Skin");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Skin", 1);
        }
        
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            #endregion
            //set up same things for Hair, Mouth and Eyes
            #region Hair
            //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
            //GUI Box or Lable on the left of the screen with the contence material Name
            //GUI button on the left of the screen with the contence >
            //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            #endregion
            #region Mouth
            //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
            //GUI Box or Lable on the left of the screen with the contence material Name
            //GUI button on the left of the screen with the contence >
            //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            #endregion
            #region Eyes
            //GUI button on the left of the screen with the contence <
            //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
            //GUI Box or Lable on the left of the screen with the contence material Name
            //GUI button on the left of the screen with the contence >
            //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            #endregion
            #region Random Reset
            //create 2 buttons one Random and one Reset
            //Random will feed a random amount to the direction 
            //reset will set all to 0 both use SetTexture
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            #endregion
            #region Character Name and Save & Play
            //name of our character equals a GUI TextField that holds our character name and limit of characters
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this

            //GUI Button called Save and Play
            //this button will run the save function and also load into the game level
            #endregion
            #endregion
    }


}
public enum CharacterClass
{
    Barbarian,
    Bard,
    Druid,
    Monk,
    Paladin,
    Ranger,
    Sorcerer,
    Warlock
}