using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cargo : MonoBehaviour
{
    private Rigidbody cargoRb;
    private float maxTorque = 10;
    private GameManager gameManager;
    public int pointValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        cargoRb = GetComponent<Rigidbody>();
        cargoRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(0, 4, 7);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnTriggerEnter(Collider Zone)
    {
        if (Zone.gameObject.tag == "Zone")
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
