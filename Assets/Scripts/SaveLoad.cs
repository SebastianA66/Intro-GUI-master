//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;
//
//public class SaveLoad : MonoBehaviour
//{
//    public static class SaveLoad
//    {
//
//        public static List<Game> savedGames = new List<Game>();
//
//    }
//
//    public static void Save()
//    {
//        savedGames.Add(Game.current);
//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
//        bf.Serialize(file, SaveLoad.savedGames);
//        file.Close();
//    }
//