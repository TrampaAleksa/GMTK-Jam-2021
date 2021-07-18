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
    private float numberOfObjectsOnButton = 0;
    private bool activatedDevice= false;
    MoveWall moveWall;

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
            numberOfObjectsOnButton++;
            print("Na buttonu " + numberOfObjectsOnButton);
            if (!moveWall.isDown && (numberOfObjectsOnButton == 1))
            {
                ActivateButton();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Character") || (boxCanActivate && other.gameObject.CompareTag("BoxCanActivate")))
        {
            numberOfObjectsOnButton--;
            if (activatedDevice && (numberOfObjectsOnButton == 0))
            {
                DeactivateButton();
            }
        }
    }
    private void ActivateButton()
    {
        EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 8);
        moveWall.numberOfObjectsThatAffectsWall++;
        moveWall.activeButtons++;
        activatedDevice = true;
        print(moveWall.activeButtons);
        AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonEnter);
    }
    private void DeactivateButton()
    {
        moveWall.activeButtons--;
        print(moveWall.activeButtons);
        activatedDevice = false;
        AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonExit);
        if (moveWall.activeButtons <= 0)
        {
            moveWall.numberOfObjectsThatAffectsWall--;
            EmissionController.SetCustomMaterialEmissionIntensityBase(mesh, 1);
        }
    }
}
