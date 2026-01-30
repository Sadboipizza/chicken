using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class waypoints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnDrawGizmos()
    {
        foreach (Transform waypoint in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(waypoint.position, 1f);

        }
        Gizmos.color = Color.green;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
          Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild((i + 1) % transform.childCount).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);

    }
    public Transform GettingNextWaypoint(Transform currentwaypoint)
    {
       if (currentwaypoint == null)
       {
           return transform.GetChild(0);
       }
       
        if (currentwaypoint.GetSiblingIndex() + 1 >= transform.childCount)
        {
            return transform.GetChild(currentwaypoint.GetSiblingIndex()+1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
}
