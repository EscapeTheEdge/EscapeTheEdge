using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorDistanceFromPlayer : MonoBehaviour
{
    Animator animator;
    GameObject playerObject;


    void Start()
    {
        animator = GetComponent<Animator>();
        playerObject = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (playerObject.transform.position, transform.position);
        animator.SetFloat("DistanceFromPlayer", distance);
        
    }
}
