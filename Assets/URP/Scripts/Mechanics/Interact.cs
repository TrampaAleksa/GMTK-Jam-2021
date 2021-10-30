using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interact : MonoBehaviour
{
    IEnumerable<IInteract> interactableObjects;
    private void Awake()
    {
        interactableObjects = FindObjectsOfType<MonoBehaviour>().OfType<IInteract>();
    }
    public void InteractOnButton()
    {
        foreach (var interact in interactableObjects)
        {
            interact.Interact();
        }
    }
}
