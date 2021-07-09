using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhomb : MonoBehaviour
{
    public bool moveWalls = false;
    [SerializeField]
    MoveWall[] wallsToOpen;

    private bool rhombActivated = false;

    public void MoveWallsDown()
    {
        for (int i = 0; i < wallsToOpen.Length; i++)
        {
            if (!wallsToOpen[i].isDown)
            {
                  rhombActivated = true;                
            }
        }
        if (rhombActivated)
        {
            for (int i = 0; i < wallsToOpen.Length; i++)
            {
                wallsToOpen[i].shouldGoDown = true;
            }
        }

    }
    public void MoveWallsUp()
    {
        if (rhombActivated)
        {
            for (int i = 0; i < wallsToOpen.Length; i++)
            {
                wallsToOpen[i].shouldGoDown = false;
            }
            rhombActivated = false;
        }
    }
}
