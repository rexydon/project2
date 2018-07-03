using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<PlayerController>().healthUp(5);
            Destroy(gameObject);
        }
    }
}
