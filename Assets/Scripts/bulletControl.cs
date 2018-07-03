using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 180;
    public int damage = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<baseUnitController>() != null)
        {
            collision.gameObject.GetComponent<baseUnitController>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
