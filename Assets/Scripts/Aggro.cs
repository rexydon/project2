using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{

    public SkeletonController controlledAI;
    private GameObject player;
    public WayPointMove wayPoints;

    public float radiusOfAggro = 10;
    public float radiusOfAttack = 5;
    public float radiusOfSatisfaction = 2;
    private bool aggroed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!controlledAI.isDead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < radiusOfAggro)
            {
                controlledAI.Seek(player.transform.position);
                aggroed = true;
            }
            if (aggroed)
            {
                if (Vector3.Distance(transform.position, player.transform.position) > radiusOfAggro)
                {
                    wayPoints.FindClosePoint();
                    aggroed = false;
                    controlledAI.isSeekTargetSet = false;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < radiusOfSatisfaction)
                {
                    controlledAI.moveDirection = Vector3.zero;
                    controlledAI.myAnimator.SetBool("IsMoving", false);
                }
                if (Vector3.Distance(transform.position, player.transform.position) < radiusOfAttack)
                {
                    StartCoroutine(controlledAI.Shoot());
                }
            }
        }
    }
}
