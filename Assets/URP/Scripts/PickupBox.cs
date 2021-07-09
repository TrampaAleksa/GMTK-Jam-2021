using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour
{
    [SerializeField]
    GameObject deviceHolder;

    float boxYAxis;
    GameObject hands;
    bool isPickedUp = false;
    Movement movement;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        boxYAxis = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            if (isPickedUp == true && movement.isActiveAndEnabled)
            {
                DropBox();
            }
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {         
            if (isPickedUp == true) return;

            if (Input.GetAxis("Fire1") > 0)
            {
                Pickup(collision.gameObject);
            }
        }
    }

    private void Pickup(GameObject collision)
    {
        hands = collision.gameObject;
        movement = hands.GetComponentInParent<Movement>();
        character = hands.GetComponentInParent<Character>();
        if (movement.isActiveAndEnabled == true && !character.isHoldingBox)
        {
            //gameObject.GetComponent<BoxCollider>().enabled = false;
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
        this.gameObject.transform.parent = deviceHolder.transform;
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
           boxYAxis, transform.position.z);
        //this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        isPickedUp = false;
        this.gameObject.GetComponent<Collider>().enabled = true;
        character.isHoldingBox = false;
    }
}
