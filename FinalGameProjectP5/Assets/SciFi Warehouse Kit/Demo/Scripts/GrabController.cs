using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public GameObject grabArea;
    bool canpickup;
    GameObject CargoCanGrab;
    bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canpickup == true)
        {
            if (Input.GetKeyDown("e"))
            {
                CargoCanGrab.GetComponent <Rigidbody>().isKinematic = true;
                CargoCanGrab.transform.position = grabArea.transform.position;
                CargoCanGrab.transform.parent = grabArea.transform;
                hasItem = true;
            }

            if (Input.GetKeyDown("q") && hasItem == true)
            {
                CargoCanGrab.GetComponent <Rigidbody>().isKinematic = false;
                CargoCanGrab.transform.parent = null;
                hasItem = false;
            }
        }
    }

    private void OnTriggerEnter(Collider cargo)
    {
        if(cargo.gameObject.tag == "cargo")
        {
            canpickup = true;
            CargoCanGrab = cargo.gameObject;
        }
    }

    private void OnTiggerExit(Collider cargo)
    {
        canpickup = false;
    }
}
