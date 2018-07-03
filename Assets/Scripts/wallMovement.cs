using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMovement : MonoBehaviour {

    public GameObject pointToRotateAround;
    public bool isRotation = false;
    public float rotationSpeed = 90;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotation == true)
        {
            Vector3 diffrence = transform.position - pointToRotateAround.transform.position;
            float rotation = rotationSpeed * Time.deltaTime;
            Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.up);
            Vector3 rotatedDiffrence = appliedRotation * diffrence;

            transform.position = pointToRotateAround.transform.position + rotatedDiffrence;

            Vector3 targetPoint = new Vector3(transform.position.x, transform.position.y,
                transform.position.z) - pointToRotateAround.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = targetRotation;
            diffrence = transform.position - pointToRotateAround.transform.position;
        }
    }
}
