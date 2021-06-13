using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelToggler : MonoBehaviour
{
    public GameObject doneImage;
    public Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }
}
