using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class GameManager : MonoBehaviour
{
    //private void OnEnable()
    //{
    //    var data = JsonConvert.DeserializeObject<LevelModel>(SaveHandler.LoadData());
    //    SceneHandler.Instance.SetId(data.NumberOfLevel);
    //}
    private void OnApplicationQuit()
    {
        LevelModel level = new LevelModel(SceneHandler.Instance.GetId());
        string levelData = JsonConvert.SerializeObject(level);
        SaveHandler.SaveData(levelData);
    }
    private void OnApplicationPause(bool pause)
    {
        //if(pause)
        //{
        //    LevelModel level = new LevelModel(SceneHandler.Instance.GetId());
        //    string levelData = JsonConvert.SerializeObject(level);
        //    SaveHandler.SaveData(levelData);
        //}
        //else
        //{
            var data = JsonConvert.DeserializeObject<LevelModel>(SaveHandler.LoadData());
            SceneHandler.Instance.SetId(data.NumberOfLevel);
        //}
    }
}
