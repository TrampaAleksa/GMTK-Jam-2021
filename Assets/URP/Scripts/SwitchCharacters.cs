using System.Collections;
using System.Collections.Generic;
using _Project.Aleksa;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    GameObject[] characters;
    Movement[] movementScripts;
    int i = 0;
    private void Awake()
    {
        characters = GameObject.FindGameObjectsWithTag("Character");
        movementScripts = new Movement[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            movementScripts[i] = characters[i].GetComponent<Movement>();
            //movementScripts[i].enabled = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        movementScripts[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            movementScripts[i++].enabled = false;
            if (i == characters.Length)
                i = 0;
            movementScripts[i].enabled = true;
            
            AudioHolder.Instance.SwapCharacters();
        }
    }
}
