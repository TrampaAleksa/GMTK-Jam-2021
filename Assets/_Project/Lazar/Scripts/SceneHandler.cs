using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;
    private static int id=0;
    private int currentLevel = 0;
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
        return currentLevel;
    }

    public int GetId()
    {
        return id;
    }
    public void SetId(int currentId)
    {
        id = currentId;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = scene.buildIndex;
    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(id);
    }

    internal void UnlockNewLevel()
    {
        if (currentLevel >= id) id = currentLevel + 1;
    }

}
