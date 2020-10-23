using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSMotor : MonoBehaviour
{
    public event Action Land = delegate { };

    [SerializeField] float cameraAngleLimit = 70f;
    private float currentCameraRotationX = 0;

    [SerializeField] Camera playerCamera = null;

    [SerializeField] GroundDetector groundDetector = null;
    bool isGrounded = false;
    
    Rigidbody playerRB = null;

    Vector3 movementThisFrame = Vector3.zero;
    float turnAmountThisFrame = 0f;
    float lookAmountThisFrame = 0f;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        groundDetector.GroundCollide += OnGroundCollide;
        groundDetector.GroundLeft += OnGroundLeave;
    }

    private void OnDisable()
    {
        groundDetector.GroundCollide -= OnGroundCollide;
        groundDetector.GroundLeft -= OnGroundLeave;
    }

    public void Move(Vector3 requestedMovement)
    {
        movementThisFrame = requestedMovement;
    }

    public void Turn(float turnAmount)
    {
        turnAmountThisFrame = turnAmount;
    }

    public void Look(float lookAmount)
    {
        lookAmountThisFrame = lookAmount;
    }

    public void Jump(float jumpForce)
    {
        if(!isGrounded)
            return;

        playerRB.AddForce(Vector3.up * jumpForce);
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementThisFrame);
        ApplyTurn(turnAmountThisFrame);
        ApplyLook(lookAmountThisFrame);
    }

    private void ApplyMovement(Vector3 movement)
    {
        if(movement == Vector3.zero)
            return;

        playerRB.MovePosition(playerRB.position + movement);
        movementThisFrame = Vector3.zero;
    }

    private void ApplyTurn(float turn)
    {
        if(turn == 0)
            return;

        Quaternion newRotation = Quaternion.Euler(0, turn, 0);
        playerRB.MoveRotation(playerRB.rotation * newRotation);

        turnAmountThisFrame = 0;
    }

    private void ApplyLook(float look)
    {
        if(look == 0)
            return;

        currentCameraRotationX -= look;
        currentCameraRotationX = Mathf.Clamp
            (currentCameraRotationX, -cameraAngleLimit, cameraAngleLimit);
        playerCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);

        lookAmountThisFrame = 0;
    }

    private void OnGroundCollide()
    {
        isGrounded = true;
        Land.Invoke();
    }

    private void OnGroundLeave()
    {
        isGrounded = false;
    }
}
