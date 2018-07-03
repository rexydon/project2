using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitController : MonoBehaviour
{
    public float rotationSpeed = 180; // degree per sec


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            other.GetComponent<PlayerController>().enabled = false;
            other.GetComponent<endLevel>().enabled = true;
            Destroy(gameObject);
        }
    }
}