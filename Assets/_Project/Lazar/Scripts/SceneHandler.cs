using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;
    private static int highestUnlockedLevelId = 0;
    private int currentLevelId = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public int GetCurrentLevel()
    {
        return currentLevelId;
    }

    public int GetId()
    {
        return highestUnlockedLevelId;
    }
    public void SetId(int currentId)
    {
        highestUnlockedLevelId = currentId;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevelId = scene.buildIndex;
    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevelId + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(highestUnlockedLevelId);
    }

    internal void UnlockNewLevel()
    {
        if (currentLevelId >= highestUnlockedLevelId) highestUnlockedLevelId = currentLevelId + 1;
    }

}
