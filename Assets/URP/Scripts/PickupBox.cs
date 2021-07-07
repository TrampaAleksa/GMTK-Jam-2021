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
                this.gameObject.transform.parent = deviceHolder.transform;
                this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                   boxYAxis, transform.position.z);
                //this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                isPickedUp = false;
                this.gameObject.GetComponent<Collider>().enabled = true;
                movement.isHoldingBox = false;
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
                hands = collision.gameObject;
                movement = hands.GetComponentInParent<Movement>();
                if (movement.isActiveAndEnabled == true && !movement.isHoldingBox)
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.transform.parent = hands.transform;
                    this.gameObject.transform.position = hands.transform.position;
                    movement.isHoldingBox = true;        
                    isPickedUp = true;
                    this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    hands.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
}
