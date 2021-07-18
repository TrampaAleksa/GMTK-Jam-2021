using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    float moveWallSpeed;
    [HideInInspector]
    public bool shouldGoDown = false;
    [HideInInspector]
    public float numberOfObjectsThatAffectsWall = 0;
    public bool isDown;
    public int activeButtons;

    float wallStartingY;
    float wallEndY;


    private void Start()
    {
        wallStartingY = gameObject.transform.localPosition.y;
        wallEndY = gameObject.transform.localPosition.y - gameObject.transform.localScale.y;
    }
    private void Update()
    {
        if (numberOfObjectsThatAffectsWall > 0)
        {
            if (gameObject.transform.localPosition.y > wallEndY)
            {
                gameObject.transform.Translate(Vector3.down * moveWallSpeed * Time.deltaTime);
                isDown = true;
            }
        }
        else
        {
            if (gameObject.transform.localPosition.y < wallStartingY)
            {
                gameObject.transform.Translate(Vector3.up * moveWallSpeed * Time.deltaTime);
                isDown = false;
            }
            
        }
    }   
}
