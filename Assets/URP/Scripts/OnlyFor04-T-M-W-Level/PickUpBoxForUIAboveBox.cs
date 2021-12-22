using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBoxForUIAboveBox : MonoBehaviour, IInteract
{
    [SerializeField]
    GameObject deviceHolder;
    [SerializeField]
    private Transform uIAboveBox;

    private bool isPickedUp = false;
    private float boxYAxis;
    private GameObject hands;
    private Character character;
    private Quaternion _rotation;
    private void Awake()
    {
        _rotation = uIAboveBox.rotation;
    }
    void Start()
    {
        boxYAxis = this.gameObject.transform.position.y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands"))
        {
            hands = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Hands"))
            hands = null;
    }

    private void Pickup()
    {
        if (!character.isHoldingBox)
        {
            this.gameObject.transform.parent = hands.gameObject.transform.parent;
            this.gameObject.transform.position = hands.transform.position;
            character.isHoldingBox = true;
            isPickedUp = true;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            hands.transform.localRotation = Quaternion.Euler(0, 0, 0);
            uIAboveBox.gameObject.SetActive(false);
        }
    }

    private void DropBox()
    {
        isPickedUp = false;
        character.isHoldingBox = false;        
        this.gameObject.transform.parent = deviceHolder.transform;
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
           boxYAxis, transform.position.z);
        uIAboveBox.gameObject.SetActive(true);
        uIAboveBox.SetPositionAndRotation(transform.position + Vector3.up * 0.15f, _rotation);
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

