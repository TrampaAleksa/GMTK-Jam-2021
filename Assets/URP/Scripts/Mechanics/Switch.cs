using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    MoveWall[] wallsToOpen;

    GameObject character;
    private bool canSwitch = false;
    private int n = 2;

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
                ActivateSwitch();
            }
        }
    }
    private void ActivateSwitch()
    {
        if (character != null)
        {
            if (character.GetComponent<Movement>().enabled)
            {
                for (int i = 0; i < wallsToOpen.Length; i++)
                {
                   // On every click adds (-1)^n, on first click it will add 1 to every wall its atached and walls will go down
                   // on second click it will add -1 to every wall and so on.
                   wallsToOpen[i].numberOfObjectsThatAffectsWall += Mathf.Pow(-1,n);
                }
                n++;
            }
        }
    }
}
