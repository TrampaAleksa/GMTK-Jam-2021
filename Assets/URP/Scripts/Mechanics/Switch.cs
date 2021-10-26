using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IOutlineWalls
{
    [SerializeField]
    MoveWall[] wallsToOpen;


    List<GameObject> character = new List<GameObject>();
    private bool thereIsWallWithStartingPositionDown;
    private int n = 2;

    private void OnCollisionEnter(Collision collision)
    {
        character.Add(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
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
    private void Awake()
    {
        ThereIsWallWithStartingPositionDown();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateSwitch();
        }
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
                            // On every click adds (-1)^n, on first click it will add 1 to every wall its atached and walls will go down
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


}
