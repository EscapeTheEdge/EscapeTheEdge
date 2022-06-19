using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    private Vector3 initialPosition;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (Time.deltaTime * speed));
        StaticClass.mapZ = transform.position.z;
        if (StaticClass.playerZ - StaticClass.mapZ > 10)
        {
            speed += 0.5f;
        } else 
        {
            speed = 1f;
        }
    }
}
