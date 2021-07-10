using System.Collections;
using System.Collections.Generic;
using _Project.Aleksa;
using _Project.Aleksa.Sounds;
using UnityEngine;

public class MethodOnButton : MonoBehaviour
{
    [SerializeField] MethodsToCall callMeethod;
    [SerializeField] GameObject wall;
    [SerializeField] bool boxCanActivate;

    MeshRenderer mesh;

    MoveWall moveWall;
    private bool activatedDevice;

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
        if (callMeethod == MethodsToCall.MoveWall)
        {
            moveWall = wall.GetComponent<MoveWall>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character") || (boxCanActivate && other.gameObject.CompareTag("BoxCanActivate")))
        {
            ActivateDevice();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character") || (boxCanActivate && other.gameObject.CompareTag("BoxCanActivate")))
        {          
            DeactivateDevice();           
        }
    }
    private void ActivateDevice()
    {
        EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 8);
        moveWall.shouldGoDown = true;
        moveWall.activeButtons++;
        print(moveWall.activeButtons);
        AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonEnter);
        activatedDevice = true;
    }
    private void DeactivateDevice()
    {
        activatedDevice = false;
        moveWall.activeButtons--;
        print(moveWall.activeButtons);
        AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonExit);
        if (moveWall.activeButtons <= 0)
        {
            moveWall.shouldGoDown = false;
            EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 1);
        }
    }
}
