using System.Collections;
using System.Collections.Generic;
using _Project.Aleksa;
using _Project.Aleksa.Sounds;
using UnityEngine;

public class MethodOnButton : MonoBehaviour
{
    [SerializeField] MethodsToCall callMeethod;
    [SerializeField] GameObject[] wall;

    MeshRenderer mesh;
    MoveWall[] moveWall;
    int objectsOnButton = 0;

    enum MethodsToCall
    {
        MoveWall,
        SomethingElse
    }
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        moveWall = new MoveWall[wall.Length];
        if (callMeethod == MethodsToCall.MoveWall)
        {
            for (int i = 0; i < wall.Length; i++)
            {
                moveWall[i] = wall[i].GetComponent<MoveWall>();
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Character") || other.gameObject.CompareTag("BoxCanActivate"))
        {
            ActivateButton(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Character") || other.gameObject.CompareTag("BoxCanActivate"))
        {
            DeactivateButton();
        }
    }
    private void ActivateButton()
    {
        EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 8);
        if(objectsOnButton == 0)
            AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonEnter);
        objectsOnButton++;
        for (int i = 0; i < wall.Length; i++)
        {
            moveWall[i].numberOfObjectsThatAffectsWall++;
        }
    }
    private void DeactivateButton()
    {
        objectsOnButton--;
        for (int i = 0; i < wall.Length; i++)
        {
            moveWall[i].numberOfObjectsThatAffectsWall--;
        }
        if (objectsOnButton <= 0)
        {
            EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 1);
            AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonExit);
        }
    }
}
