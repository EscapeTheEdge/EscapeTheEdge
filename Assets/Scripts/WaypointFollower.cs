using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] bool withRotation = false;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f){
            currentWaypointIndex ++;
            if (currentWaypointIndex >= waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        
        if(withRotation){
            transform.LookAt(waypoints[currentWaypointIndex].transform,Vector3.up);
        }
    }
}
