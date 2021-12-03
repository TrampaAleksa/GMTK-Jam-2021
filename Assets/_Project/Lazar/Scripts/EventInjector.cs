using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInjector : MonoBehaviour
{
    SceneHandler handler;
    void Start()
    {
        handler = FindObjectOfType<SceneHandler>();
    }

    public void LoadScene(int id)
    {
        handler.LoadScene(id);
    }
    public void NextLevel()
    {
        var id = handler.GetId();
        handler.LoadScene(id);
    }
    public void RestartLevel()
    {
        var id=handler.GetId();
        handler.LoadScene(id);
    }


}
