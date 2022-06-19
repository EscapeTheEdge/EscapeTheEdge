using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] private AnimationCurve cameraAnimation;
    [SerializeField] private int noSpeedupMargin = 2;
    [SerializeField] private float maxAdditionalSpeed = 10f;
    [SerializeField] private float speedupMargin = 7f;
    private Vector3 initialPosition;
    private float speed;
    // private Vector3 direction = new(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticClass.playerZ == 0)
        {
            speed = 0f;
        }

        transform.position += direction * (Time.deltaTime * speed);
        StaticClass.mapZ = transform.position.z;
        speed = 1f + cameraAnimation.Evaluate((StaticClass.playerZ - StaticClass.mapZ - noSpeedupMargin) / speedupMargin) * maxAdditionalSpeed;
    }
}
