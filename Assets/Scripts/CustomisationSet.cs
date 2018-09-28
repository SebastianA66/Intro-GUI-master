using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour
{

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
    //public int Strength;
    //public int Dexterity;
    //public int Constitution;
    //public int Intelligence;
    //public int Wisdom;
    //public int Charisma;
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];

    //the points which we use to increase stats
    public int skillPoint = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;
    public string chooseClass = "Choose Class";

    [Header("GUI")]
    public Vector2[] res;
    public int index;
    public bool showDrop;
    public Vector2 scrollPos;
    public string resolution = "Resolution";
    public bool fullScr;

    #endregion

    #region Start
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[]
        {
            "Strength" , "Dexterity" , "Constitution" , "Wisdom" , "Intelligence" , "Charisma"
        };

        selectedClass = new string[]
        {
            "Barbarian" , "Bard" , "Druid" , "Monk" , "Paladin" , "Ranger" , "Sorcerer" , "Warlock"
        };

        //in start we need to set up the following

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of hair textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of mouth textures we need 
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }


        //for loop looping from 0 to less than the max amount of eyes textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }

        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(temp);
        }

        for (int i = 0; i < armourMax; i++)
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
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Armour", 0);
        SetTexture("Clothes", 0);
        ChooseClass(selectedIndex);

        #endregion
    }
    #endregion

    

    void ChooseClass(int className)
    {
        skillPoint = 10;

        switch (className)
        {
            case 0:
                //Total 15
                stats[0] = 6;
                stats[1] = 3;
                stats[2] = 3;
                stats[3] = 1;
                stats[4] = 1;
                stats[5] = 1;
                charClass = CharacterClass.Barbarian;
                break;

            case 1:
                // Total 15
                stats[0] = 1;
                stats[1] = 1;
                stats[2] = 2;
                stats[3] = 5;
                stats[4] = 3;
                stats[5] = 3;
                charClass = CharacterClass.Bard;
                break;

            case 2:
                // Total 15
                stats[0] = 1;
                stats[1] = 1;
                stats[2] = 3;
                stats[3] = 4;
                stats[4] = 4;
                stats[5] = 2;
                charClass = CharacterClass.Druid;
                break;

            case 3:
                // Total 15
                stats[0] = 1;
                stats[1] = 2;
                stats[2] = 2;
                stats[3] = 4;
                stats[4] = 3;
                stats[5] = 3;
                charClass = CharacterClass.Monk;
                break;

            case 4:
                // Total 15
                stats[0] = 4;
                stats[1] = 4;
                stats[2] = 4;
                stats[3] = 1;
                stats[4] = 1;
                stats[5] = 1;
                charClass = CharacterClass.Paladin;
                break;

            case 5:
                // Total 15
                stats[0] = 2;
                stats[1] = 6;
                stats[2] = 3;
                stats[3] = 2;
                stats[4] = 1;
                stats[5] = 1;
                charClass = CharacterClass.Ranger;
                break;

            case 6:
                // Total 15
                stats[0] = 1;
                stats[1] = 1;
                stats[2] = 1;
                stats[3] = 5;
                stats[4] = 6;
                stats[5] = 1;
                charClass = CharacterClass.Sorcerer;
                break;

            case 7:
                // Total 15
                stats[0] = 1;
                stats[1] = 3;
                stats[2] = 1;
                stats[3] = 3;
                stats[4] = 6;
                stats[5] = 1;
                charClass = CharacterClass.Warlock;
                break;
        }
    }

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
        switch (type)
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
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
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
        switch (type)
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
        PlayerPrefs.SetString("CharacterName", charName);
        for (int i = 0; i < stats.Length; i++)
        {
            PlayerPrefs.SetInt(statArray[i], stats[i] + tempStats[i]);
        }
        // Save to regedit a string called CharacterClass with the data selectedClass[selectedIndex] which is our current class
        PlayerPrefs.SetString("CharacterClass", selectedClass[selectedIndex]);
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
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
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
        i++;
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        //set up same things for Hair, Mouth and Eyes
        #region Hair
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  -1
            SetTexture("Hair", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Hair
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Hair");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        #endregion
        #region Mouth
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Mouth Material and move the texture index in the direction  -1
            SetTexture("Mouth", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Mouth
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Mouth");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);
        }
        i++;
        #endregion
        #region Eyes
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Eyes Material and move the texture index in the direction  -1
            SetTexture("Eyes", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Eyes
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Eyes");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);
        }
        i++;
        #endregion
        #region Armour
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Armour Material and move the texture index in the direction  -1
            SetTexture("Armour", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Armour
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Armour");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Armour", 1);
        }
        i++;
        #endregion
        #region Clothes
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Clothes Material and move the texture index in the direction  -1
            SetTexture("Clothes", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Clothes
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Clothes");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMax - 1));
            SetTexture("Hair", Random.Range(0, hairMax - 1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
        }
        i++;
        #region Character Name and Save & Play
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        charName = GUI.TextField(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), charName, 16);
        i++;
        //GUI Button called Save and Play
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Save & Play"))
        {
            //this button will run the save function and also load into the game level
            Save();
            SceneManager.LoadScene(1);
        }
        i = 0;
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrH), "Skill Point:" + skillPoint);

        for (int s = 0; s < 6; s++)
        {
            if (skillPoint > 0)
            {
                if (GUI.Button(new Rect(5.75f * scrW, 1.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
                {
                    skillPoint--;
                    tempStats[s]++;
                }
            }

            GUI.Box(new Rect(3.75f * scrW, 1.5f * scrH + s * (0.5f * scrH), 2f * scrW, 0.5f * scrH), statArray[s] + ":" + (stats[s]+tempStats[s]));
            if (skillPoint < 10 && tempStats[s] > 0)
            {
                if (GUI.Button(new Rect(3.25f * scrW, 1.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
                {
                    skillPoint++;
                    tempStats[s]--;
                }
            }
        }
        i++;
        i++;
        i++;
        i++;
        i++;
        i++;

        if (GUI.Button(new Rect(3.75f * scrW, 1.5f * scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            ChooseClass(0);
            skillPoint = 10;
            for (int s = 0; s < 6; s++)
            {
            tempStats[s] = 0;

            }

        }
     
        i = 0;
        if (GUI.Button(new Rect(13.25f * scrW, 0.25f*scrH + i * (0.5f * scrH), 2.5f * scrW, 0.5f * scrH), chooseClass))
        {
            showDrop = !showDrop;
        }
        i++;
        if (showDrop)
        {
            GUI.BeginScrollView(new Rect(13.25f * scrW, 0.25f * scrH + i * (0.5f * scrH), 2.5f * scrW, 4f * scrH),scrollPos,new Rect(0,0,2.5f*scrW,4*scrH));
            for (int c = 0; c < selectedClass.Length; c++)
            {
                if (GUI.Button(new Rect(0, 0 + c * (0.5f * scrH), 2.5f * scrW, 0.5f * scrH), selectedClass[c]))
                {
                    selectedIndex = c;
                    ChooseClass(c);
                    chooseClass = selectedClass[c];
                    //charClass = CharacterClass.Barbarian;


                    showDrop = !showDrop;
                }
            }
            GUI.EndScrollView();
        }
       
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        

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
