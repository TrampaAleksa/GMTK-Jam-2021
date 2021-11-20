using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour
{
    public Button[] buttons;
    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }
    void Start()
    {
        var lastLevelId=SceneHandler.Instance.GetId();
        for(int i=0;i< lastLevelId; i++)
        {
            buttons[i].interactable = true;
            Debug.Log(i);
            //if (i < lastLevelId - 1)
            //{
            //    buttons[i].doneImage.SetActive(true);
            //    Debug.Log(i);
            //}
        }
    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
