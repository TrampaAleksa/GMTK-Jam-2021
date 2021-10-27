using System;
using System.IO;
using TMPro;
using UnityEngine;
public class FileManager : MonoBehaviour
{
    const string DATA_NAME = "data.txt";
    public static string DataPath = string.Empty;
    public static void extendSaveData(string text, string path)
    {
        FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        file.Position = file.Length;
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(text);

        sw.Close();
        file.Close();
    }
    public static void overrideToTxt(string text, string path)
    {
        File.WriteAllText(path, text);
    }
    public static string loadToTxt(string path)
    {
        FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

        StreamReader sw = new StreamReader(file);
        var text=sw.ReadToEnd();

        sw.Close();
        file.Close();
        return text;
    }
    private void Awake()
    {
        DataPath = Application.dataPath + "/" + DATA_NAME;
    }
}
