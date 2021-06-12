using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    float moveWallSpeed;
    [HideInInspector]
    public bool shouldGoDown = false;

    float wallStartingY;
    float wallEndY;  


    private void Start()
    {
        wallStartingY = gameObject.transform.localPosition.y;
        wallEndY = gameObject.transform.localPosition.y - gameObject.transform.localScale.y;
    }
    private void Update()
    {
        if (shouldGoDown)
        {
            if (gameObject.transform.localPosition.y > wallEndY)
                gameObject.transform.Translate(Vector3.down * moveWallSpeed * Time.deltaTime);
        }
        else
        {
            if (gameObject.transform.localPosition.y < wallStartingY)
                gameObject.transform.Translate(Vector3.up * moveWallSpeed * Time.deltaTime);
        }
    }
}
