using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IOutlineWalls, IInteract
{
    [SerializeField]
    MoveWall[] wallsToOpen;


    List<GameObject> character = new List<GameObject>();
    bool thereIsWallWithStartingPositionDown;
    int n = 2;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
            character.Add(collision.gameObject);

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))       
            character.Remove(collision.gameObject);  
    }
    void IOutlineWalls.OutlineWalls()
    {
        OutlineWalls.OutlineWall(wallsToOpen);
    }
    void IOutlineWalls.StopOutline()
    {
        OutlineWalls.ResetWallsLayer(wallsToOpen);
    }
    void Awake()
    {
        ThereIsWallWithStartingPositionDown();
    }

    private void ThereIsWallWithStartingPositionDown()
    {
        for (int i = 0; i < wallsToOpen.Length; i++)
        {
            if (wallsToOpen[i].startingPositionIsDown)
            {
                thereIsWallWithStartingPositionDown = true;
                return;
            }
        }
        thereIsWallWithStartingPositionDown = false;
    }
    private void ActivateSwitch()
    {
        if (character.Count != 0)
        {
            foreach (GameObject robot in character)
            {
                if (robot.GetComponent<Movement>().enabled)
                {
                    if (thereIsWallWithStartingPositionDown)
                    {
                        for (int i = 0; i < wallsToOpen.Length; i++)
                        {
                            // On every click adds (-1)^n, on first click it will add 1 to every wall
                            // its atached and walls will go down
                            // on second click it will add -1 to every wall and so on.
                            if (wallsToOpen[i].startingPositionIsDown)
                            {
                                wallsToOpen[i].numberOfObjectsThatAffectsWall += Mathf.Pow(-1, n - 1);
                                continue;
                            }
                            wallsToOpen[i].numberOfObjectsThatAffectsWall += Mathf.Pow(-1, n);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < wallsToOpen.Length; i++)
                        {
                            wallsToOpen[i].numberOfObjectsThatAffectsWall += Mathf.Pow(-1, n);
                        }
                    }
                    n++;
                    break;
                }
            }
        }
    }

    void IInteract.Interact()
    {
        ActivateSwitch();
    }


}
