using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData data;
    private string file = "highScore.txt";
    // Start is called before the first frame update
    public void save()
    {
        string json = JsonUtility.ToJson(data);
        writeToFile(file, json);
    }

    public void Load()
    {
        data = new PlayerData();
        string json = readFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    private void writeToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream filestream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(filestream))
        {
            writer.Write(json);
        }
    }
    private string readFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.Log("File not found");
            return "";
        }
    }
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
