using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cargo : MonoBehaviour
{
    private Rigidbody cargoRb;
    private GameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(0, 4, 8);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Zone)
    {
        if (Zone.gameObject.tag == "cargo")
        gameManager.UpdateScore(pointValue);
    }
}
