using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhomb : MonoBehaviour
{
    public bool moveWalls = false;
    [SerializeField]
    MoveWall[] wallsToOpen;

    public void MoveWallsDown()
    {

        for (int i = 0; i < wallsToOpen.Length; i++)
        {
            wallsToOpen[i].numberOfObjectsThatAffectsWall++;
        }
    }
    public void MoveWallsUp()
    {
        for (int i = 0; i < wallsToOpen.Length; i++)
        {
            wallsToOpen[i].numberOfObjectsThatAffectsWall--;
        }
    }
}
