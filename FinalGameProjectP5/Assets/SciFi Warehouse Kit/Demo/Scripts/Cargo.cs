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

        transform.position = new Vector3(Random.Range(8, 9), 4);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Zone)
    {
        if (Zone.GetComponent<Rigidbody>())
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
    }
}
