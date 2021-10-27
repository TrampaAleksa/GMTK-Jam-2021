using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveHandler
{
    public static void SaveData(string data)
    {
        FileManager.overrideToTxt(data, FileManager.DataPath);
    }

    public static string LoadData()
    {
        return FileManager.loadToTxt(FileManager.DataPath);
    }
}
