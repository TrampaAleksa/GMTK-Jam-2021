using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour, IInteract
{
    [SerializeField]
    GameObject deviceHolder;
     
    private bool isPickedUp = false;
    private float boxYAxis;
    private GameObject hands;
    private Character character;
    private GameObject characterCollision;
    // Start is called before the first frame update
    void Start()
    {
        boxYAxis = this.gameObject.transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands")) 
            characterCollision = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands")) 
            characterCollision = null;
    }

    private void Pickup()
    {
        if (!character.isHoldingBox)
        {
            this.gameObject.transform.parent = hands.transform;
            this.gameObject.transform.position = hands.transform.position;
            character.isHoldingBox = true;
            isPickedUp = true;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            hands.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void DropBox()
    {
        isPickedUp = false;
        character.isHoldingBox = false;
        this.gameObject.transform.parent = deviceHolder.transform;
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
           boxYAxis, transform.position.z);
    }
    void IInteract.Interact()
    {
        if (characterCollision == null) return;
        if (!characterCollision.GetComponentInParent<Movement>().enabled) return;
        hands = characterCollision.gameObject;
        character = hands.GetComponentInParent<Character>();
        if (character.isHoldingBox) DropBox();
        else Pickup();
        Interact.IsActivated = true;
    }
}
