using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //[SerializeField] AudioSource pickUp;
    //[SerializeField] AudioSource drop;
    private static bool isPickedUp;
    //[SerializeField] Vector3 sizeOfPickedUpDevice;
    //[SerializeField] Vector3 sizeAfterDropping;

    private float vratiDeviceNaVisinu;

    private GameObject robot;

    private GameObject pickedUpDevice;

    public GameObject deviceHolder;

    private static string pickedUpDeviceName = " ";

    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
        robot = GameObject.FindGameObjectWithTag("Character");
        pickedUpDevice = GameObject.FindGameObjectWithTag("PickedUpDevice");
        vratiDeviceNaVisinu = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            if (isPickedUp == true && pickedUpDeviceName == gameObject.name)
            {
              //  drop.Play();
                this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    vratiDeviceNaVisinu, transform.position.z);

                // transform.localScale = sizeAfterDropping;
                this.gameObject.transform.parent = deviceHolder.transform;
                isPickedUp = false;
                this.gameObject.GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (isPickedUp == true) return;
            //print("Click left mouse button to pick device up!");
            if (Input.GetAxis("Fire1") > 0)
            {
                //pickUp.Play();
                this.gameObject.transform.parent = collision.transform;
                this.gameObject.transform.position = pickedUpDevice.transform.position;
                isPickedUp = true;

                // pokupljen device iznad glave               

                // transform.localScale = sizeOfPickedUpDevice;
                this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                this.gameObject.GetComponent<Collider>().enabled = false;

                //pickedUpDeviceName = gameObject.name;
            }
        }
    }

}