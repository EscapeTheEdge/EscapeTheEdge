using System;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float meshSize = 1f;
    [SerializeField] Vector3 meshOffset;
    [SerializeField] private float moveDuration = 0.2f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AnimationCurve animation;

    private Boolean isMoving;
    private Vector3 meshPosition;
    private Vector3 goalMeshPosition;
    private Vector3 worldPosition;
    private Vector3 goalWorldPosition;
    private float moveStartTime;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        worldPosition = meshOffset;
        goalWorldPosition = meshOffset;
        StaticClass.playerZ = 0;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) Move();
        CheckInput();
    }

    public int GetProgress()
    {
        return (int)meshPosition.z;
    }

    private void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            StartMove(new Vector3(-1, 0, 0));
        }

        ;
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            StartMove(new Vector3(1, 0, 0));
        }

        ;
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            StartMove(new Vector3(0, 0, 1));
        }

        ;
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            StartMove(new Vector3(0, 0, -1));
        }

        ;
    }

    private void StartMove(Vector3 direction)
    {
        if (isMoving) EndMove();
        if (!canMove(direction)) return;

        goalMeshPosition = meshPosition + direction;
        goalWorldPosition = (goalMeshPosition * meshSize) + meshOffset;
        isMoving = true;
        moveStartTime = Time.time;
    }

    private void Move()
    {
        if (Time.time > moveStartTime + moveDuration)
        {
            EndMove();
            return;
        }

        var interpolation = (Time.time - moveStartTime) / moveDuration;

        var movement = Vector3.Lerp(worldPosition, goalWorldPosition, animation.Evaluate(interpolation));
        rb.transform.position = movement;
        StaticClass.playerZ = movement.z;
    }

    private void EndMove()
    {
        isMoving = false;
        rb.transform.position = goalWorldPosition;
        worldPosition = goalWorldPosition;
        meshPosition = goalMeshPosition;
    }

    private bool canMove(Vector3 direction)
    {
        LayerMask mask = LayerMask.GetMask("Barrier");
        bool barrier = Physics.Raycast(transform.position, direction, 1f, mask);
        int nextX = (int)(meshPosition.x + direction.x);
        bool mapLimit = nextX < 10 && nextX > -10;
        return !barrier && mapLimit;
    }

    bool IsPlayerTouchingGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}