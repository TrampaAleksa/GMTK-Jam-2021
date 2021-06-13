using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodOnButton : MonoBehaviour
{
    [SerializeField] MethodsToCall callMeethod;
    [SerializeField] GameObject wall;
    [SerializeField] EmissionController emission;
    [SerializeField] MeshRenderer mesh;

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
            emission.SetCustomMaterialEmissionIntensity(mesh, 8);
            moveWall.shouldGoDown = true;
            moveWall.activeButtons++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            emission.SetCustomMaterialEmissionIntensity(mesh, 1);
            moveWall.activeButtons--;

            if (moveWall.activeButtons <= 0)
            {
                moveWall.shouldGoDown = false;
            }
        }
    }
}