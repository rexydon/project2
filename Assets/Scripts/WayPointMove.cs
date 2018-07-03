using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMove : MonoBehaviour
{

    public GameObject waypointList;
    private List<Vector3> waypoints = new List<Vector3>();
    private int count = 0;
    public SkeletonController controlledAI;


    // Use this for initialization
    void Start()
    {
        foreach (Transform child in waypointList.transform)
        {
            waypoints.Add(child.position);
        }
        FindClosePoint();
     }

    // Update is called once per frame
    void Update()
    {
        if(!controlledAI.isDead)
        {
            if (!controlledAI.isSeekTargetSet)
            {
                controlledAI.Seek(waypoints[count++]);
                if (count == waypoints.Count)
                {
                    count = 0;
                }
            }
        }
    }

    public void FindClosePoint()
    {
        float position = 20000;
        int pointToGo = 0;
        for (int i = 1; i <= waypoints.Count; i++ )
        {
            if (Vector3.Distance(waypoints[i - 1], transform.position) < position)
            {
                position = Vector3.Distance(waypoints[i - 1], transform.position);
                pointToGo = i - 1;
            }
        }
        count = pointToGo;
    }
}
