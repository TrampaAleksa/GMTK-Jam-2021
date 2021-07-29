using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public bool startingPositionIsDown;
    [SerializeField]
    float moveWallSpeed;
    [HideInInspector]
    public float numberOfObjectsThatAffectsWall = 0;


    float wallStartingY;
    float wallEndY;


    private void Awake()
    {
        wallStartingY = gameObject.transform.localPosition.y;
        wallEndY = gameObject.transform.localPosition.y - gameObject.transform.localScale.y;
        if (startingPositionIsDown)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, wallEndY, transform.localPosition.z);
            numberOfObjectsThatAffectsWall++;
        }
    }
    private void Update()
    {
        if (numberOfObjectsThatAffectsWall > 0)
        {
            if (gameObject.transform.localPosition.y > wallEndY)
            {
                gameObject.transform.Translate(Vector3.down * moveWallSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (gameObject.transform.localPosition.y < wallStartingY)
            {
                gameObject.transform.Translate(Vector3.up * moveWallSpeed * Time.deltaTime);
            }
            
        }
    }   
}
