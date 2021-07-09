using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    MoveWall[] wallsToOpen;

    GameObject character;
    private bool canSwitch = false;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        character = collision.gameObject;
        canSwitch = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        character = null;
        canSwitch = false;
    }
    private void Update()
    {
        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (character != null)
                {
                    if (character.GetComponent<Movement>().enabled)
                    {
                        for (int i = 0; i < wallsToOpen.Length; i++)
                        {
                            wallsToOpen[i].shouldGoDown = !wallsToOpen[i].shouldGoDown;
                        }
                    }
                }
            }
        }
    }
}
