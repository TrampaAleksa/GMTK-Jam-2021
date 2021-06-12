using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodOnButton : MonoBehaviour
{
    [SerializeField]
    MethodsToCall callMeethod;
    [SerializeField]
    GameObject wall;

    bool shouldMoveWall = false;
    MoveWall moveWall;
    
    enum MethodsToCall
    {
        MoveWall,
        SomethingElse
    }

    // Start is called before the first frame update
    void Start()
    {
        if(callMeethod == MethodsToCall.MoveWall)
        {
            shouldMoveWall = true;
            moveWall = wall.GetComponent<MoveWall>();
        }
    }
    // Update is called once per frame
    void Update()
    {     
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            if (shouldMoveWall)
                moveWall.shouldGoDown = true;
        }           
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            if (shouldMoveWall)
                moveWall.shouldGoDown = false;
        }            
    }
}
