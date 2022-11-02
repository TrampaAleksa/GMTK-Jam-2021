using System.Collections;
using System.Collections.Generic;
using _Project.Aleksa;
using _Project.Aleksa.Sounds;
using UnityEngine;

public class MethodOnButton : MonoBehaviour, IOutlineWalls
{
    [SerializeField] GameObject[] wall;

    MeshRenderer mesh;
    MoveWall[] moveWall;
    int objectsOnButton = 0;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        EmissionController.Instance.ToggleEmission(false, mesh);
        moveWall = new MoveWall[wall.Length];
        for (int i = 0; i < wall.Length; i++)
        {
            moveWall[i] = wall[i].GetComponent<MoveWall>();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Character") || other.gameObject.CompareTag("BoxCanActivate"))
        {
            ActivateButton(); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character") || other.gameObject.CompareTag("BoxCanActivate"))
        {
            DeactivateButton();
        }
    }
    void ActivateButton()
    {
        EmissionController.Instance.ToggleEmission(true, mesh);
        if(objectsOnButton == 0)
            AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonEnter);
        objectsOnButton++;
        for (int i = 0; i < wall.Length; i++)
        {
            moveWall[i].numberOfObjectsThatAffectsWall++;
        }
    }
    void DeactivateButton()
    {
        objectsOnButton--;
        for (int i = 0; i < wall.Length; i++)
        {
            moveWall[i].numberOfObjectsThatAffectsWall--;
        }
        if (objectsOnButton <= 0)
        {
            EmissionController.Instance.ToggleEmission(false, mesh);
            AudioHolder.Instance.ActivateButton(ButtonSoundType.ButtonExit);
        }
    }
    void IOutlineWalls.OutlineWalls()
    {
        OutlineWalls.OutlineWall(moveWall);
    }
    void IOutlineWalls.StopOutline()
    {
        OutlineWalls.ResetWallsLayer(moveWall);
    }
}
