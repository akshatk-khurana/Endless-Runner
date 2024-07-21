using System.IO;
using UnityEngine;

public static class Save 
{
    public static readonly string PATH = Application.persistentDataPath + "/saves/";
    public static readonly string EXTENSION = ".json";

    public static void SaveData(string fileName, string data) {
        if (!Directory.Exists(PATH)) {
            Directory.CreateDirectory(PATH);
        }

        File.WriteAllText(PATH + fileName + EXTENSION, data);
    }

    public static string LoadData(string fileName) {
        string location = PATH + fileName + EXTENSION;
        if (File.Exists(location)) {
            string data = File.ReadAllText(location);
            return data;
        } else {
            return null;
        }
    }
}
