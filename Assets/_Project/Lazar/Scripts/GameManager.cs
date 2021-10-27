using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (Int32.TryParse(SaveHandler.LoadData(), out int id))
        {
            SceneHandler.Instance.SetId(id);
        }
    }
    private void OnApplicationQuit()
    {
        LevelModel level = new LevelModel(SceneHandler.Instance.GetId());
        string levelData = JsonConvert.SerializeObject(level);
        SaveHandler.SaveData(levelData);
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            LevelModel level = new LevelModel(SceneHandler.Instance.GetId());
            string levelData = JsonConvert.SerializeObject(level);
            SaveHandler.SaveData(levelData);
        }
        else
        {
            if(Int32.TryParse(SaveHandler.LoadData(), out int id))
            {
                SceneHandler.Instance.SetId(id);
            }
        }
    }
}
