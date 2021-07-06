using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    MoveWall[] wallsToOpen;

    private bool canSwitch = false;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        canSwitch = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        canSwitch = false;
    }
    private void Update()
    {
        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < wallsToOpen.Length; i++)
                {
                    wallsToOpen[i].shouldGoDown = !wallsToOpen[i].shouldGoDown;
                }
            }
        }
    }
}
