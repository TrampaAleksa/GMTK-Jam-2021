using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interact : MonoBehaviour
{

    IEnumerable<IInteract> interactBoxes;
    IEnumerable<IInteract> interactSwitches;

    private void Awake()
    {
        interactBoxes = FindObjectsOfType<MonoBehaviour>().OfType<PickupBox>();
        interactSwitches = FindObjectsOfType<MonoBehaviour>().OfType<Switch>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) InteractOnButton();
    }
    public void InteractOnButton()
    {
        IsActivated = false;
        foreach (var interactBox in interactBoxes)
        {
            interactBox.Interact();
        }
        // if there was interaction with any box don't iteract with switch
        if (IsActivated) return;
        foreach (var interactSwitch in interactSwitches)
        {
            interactSwitch.Interact();
        }
    }

    static public bool IsActivated { get; set; }
}
