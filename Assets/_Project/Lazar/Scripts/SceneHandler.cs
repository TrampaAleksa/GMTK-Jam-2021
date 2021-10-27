using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;
    private static int id=0;
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
        if(scene.buildIndex!=0)
            id = scene.buildIndex;
    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(id+1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(id);
    }
}
