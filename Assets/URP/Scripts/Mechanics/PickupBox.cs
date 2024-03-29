using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour, IInteract
{
    [SerializeField]
    GameObject deviceHolder;
     
    bool isPickedUp = false;
    float boxYAxis;
    GameObject hands;
    Character character;
    void Start()
    {
        boxYAxis = this.gameObject.transform.position.y;
    }
    void OnTriggerEnter(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands"))
        {
            hands = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands")) 
            hands = null;
    }

    void Pickup()
    {
        if (!character.isHoldingBox)
        {
            this.gameObject.transform.parent = hands.gameObject.transform.parent;
            this.gameObject.transform.position = hands.transform.position;
            character.isHoldingBox = true;
            isPickedUp = true;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            hands.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void DropBox()
    {
        isPickedUp = false;
        character.isHoldingBox = false;
        this.gameObject.transform.parent = deviceHolder.transform;
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
           boxYAxis, transform.position.z);
    }
    void IInteract.Interact()
    {
        if (hands == null) return;
        if (!hands.GetComponentInParent<Movement>().enabled) return;
        character = hands.GetComponentInParent<Character>();
        if (character.isHoldingBox) DropBox();
        else Pickup();
        Interact.IsActivated = true;
    }
}
