using Unity.Mathematics;
using UnityEngine;

public class Rotatething : MonoBehaviour
{
    public quaternion rotation;
    public float speed = 1f;
    public waypoints waypoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( waypoints.transform.childCount > 0)
        {
            Transform targetWaypoint = waypoints.transform.GetChild(0);
            quaternion targetRotation = quaternion.LookRotationSafe(math.normalize(targetWaypoint.position - transform.position), math.up());
            rotation = math.slerp(rotation, targetRotation, speed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
