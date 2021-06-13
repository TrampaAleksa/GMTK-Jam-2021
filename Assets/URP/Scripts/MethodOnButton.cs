using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodOnButton : MonoBehaviour
{
    [SerializeField] MethodsToCall callMeethod;
    [SerializeField] GameObject wall;

    MoveWall moveWall;

    enum MethodsToCall
    {
        MoveWall,
        SomethingElse
    }

    // Start is called before the first frame update
    void Start()
    {
        if (callMeethod == MethodsToCall.MoveWall)
        {
            moveWall = wall.GetComponent<MoveWall>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            moveWall.shouldGoDown = true;
            moveWall.activeButtons++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            moveWall.activeButtons--;

            if (moveWall.activeButtons <= 0)
            {
                moveWall.shouldGoDown = false;
            }
        }
    }
}