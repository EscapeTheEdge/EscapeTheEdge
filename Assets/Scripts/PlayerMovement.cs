using System;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float meshSize = 1f;
    [SerializeField] Vector3 meshOffset;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private Boolean isMoving;
    private Vector3 meshPosition;
    private Vector3 goalMeshPosition;
    private Vector3 worldPosition;
    private Vector3 goalWorldPosition;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) Move();
        else CheckInput();
        // rb.velocity = new Vector3(horizontalInput*movementSpeed, rb.velocity.y, verticalInput*movementSpeed);

        // if (Input.GetButtonDown("Jump") && IsPlayerTouchingGround()){
        // Jump();
        // }
    }

    private void CheckInput()
    {
        int horizontalInput = Math.Sign(Input.GetAxis("Horizontal"));
        int verticalInput = Math.Sign(Input.GetAxis("Vertical"));


        if (horizontalInput != 0) StartMove(new Vector3(horizontalInput, 0, 0));
        if (verticalInput != 0) StartMove(new Vector3(0, 0, verticalInput));
    }

    private void StartMove(Vector3 direction)
    {
        goalMeshPosition = meshPosition + direction;
        goalWorldPosition = (goalMeshPosition * meshSize) + meshOffset;
        isMoving = true;
    }

    private void Move()
    {
        if (rb.transform.position == goalWorldPosition)
        {
            isMoving = false;
            worldPosition = goalWorldPosition;
            meshPosition = goalMeshPosition;
            return;
        }

        Vector3 movement = Vector3.MoveTowards(rb.transform.position, goalWorldPosition, 2f * Time.deltaTime);
        rb.transform.position = movement;
    }
}