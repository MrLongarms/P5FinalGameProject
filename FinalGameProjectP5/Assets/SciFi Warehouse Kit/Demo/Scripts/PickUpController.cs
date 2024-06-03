using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject myHands;
    bool canpickup;
    GameObject CargoIwantToPickUp;
    bool hasItem;

    // Start is called before the first frame update
    private void Start()
    {
        canpickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(canpickup == true)
        {
            if (Input.GetKeyDown("e"))
            {
                CargoIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;
                CargoIwantToPickUp.transform.position = myHands.transform.position;
                CargoIwantToPickUp.transform.parent = myHands.transform;
            }
            hasItem = true;
        }

        while(hasItem == true)
        {
            canpickup = false;
        }

        if (Input.GetKeyDown("q") && hasItem == true)
        {
            CargoIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false;
            CargoIwantToPickUp.transform.parent = null;
            hasItem = false;
        }
    }

    private void OnTriggerEnter(Collider cargo)
    {
        if(cargo.gameObject.tag == "cargo")
        {
            canpickup = true;
            CargoIwantToPickUp = cargo.gameObject;
        }
    }

    private void OnTriggerExit(Collider cargo)
    {
        canpickup = false;
    }
}