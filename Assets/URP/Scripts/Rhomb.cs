using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhomb : MonoBehaviour
{
    public bool moveWalls = false;
    [SerializeField]
    MoveWall[] wallsToOpen;
    Signal signal;

    private bool move = false;
    public void MoveWallsDown()
    {
        for (int i = 0; i < wallsToOpen.Length; i++)
        {
            if (!wallsToOpen[i].isDown)
            {
                  move = true;                
            }
        }
        if (move)
        {
            for (int i = 0; i < wallsToOpen.Length; i++)
            {
                wallsToOpen[i].shouldGoDown = true;
            }
        }

    }
    public void MoveWallsUp()
    {
        if (move)
        {
            for (int i = 0; i < wallsToOpen.Length; i++)
            {
                wallsToOpen[i].shouldGoDown = false;
            }
            move = false;
        }
    }
}
