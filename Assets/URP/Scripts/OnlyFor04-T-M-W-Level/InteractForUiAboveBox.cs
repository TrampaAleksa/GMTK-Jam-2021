using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractForUiAboveBox : MonoBehaviour
{
    IEnumerable<IInteract> interactBoxes;

    private void Awake()
    {
        interactBoxes = FindObjectsOfType<MonoBehaviour>().OfType<PickUpBoxForUIAboveBox>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) InteractOnButton();
    }
    public void InteractOnButton()
    {
        foreach (var interactBox in interactBoxes)
        {
            interactBox.Interact();
        }
    }

    static public bool IsActivated { get; set; }
}
