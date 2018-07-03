using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToChild : baseUnitController
{
    public GameObject child;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TakeDamage(int damage)
    {
        child.GetComponent<SkeletonController>().TakeDamage(damage);
    }
}
