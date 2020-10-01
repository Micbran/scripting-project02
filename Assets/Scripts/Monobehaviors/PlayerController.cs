using UnityEngine;

[RequireComponent(typeof(FPSInput))]
[RequireComponent(typeof(FPSMotor))]
public class PlayerController : MonoBehaviour
{
    FPSInput input = null;
    FPSMotor motor = null;

    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float turnSpeed = 6f;
    [SerializeField] float jumpForce = 10f;

    private void Awake()
    {
        input = GetComponent<FPSInput>();
        motor = GetComponent<FPSMotor>();
    }

    private void OnEnable()
    {
        input.MoveInput += OnMove;
        input.RotateInput += OnRotate;
        input.JumpInput += OnJump;
    }

    private void OnDisable()
    {
        input.MoveInput -= OnMove;
        input.RotateInput -= OnRotate;
        input.JumpInput -= OnJump;
    }

    private void OnMove(Vector3 movement)
    {
        motor.Move(movement * moveSpeed);
    }

    private void OnRotate(Vector3 rotation)
    {
        motor.Turn(rotation.y * turnSpeed);
        motor.Look(rotation.x * turnSpeed);
    }

    private void OnJump()
    {
        motor.Jump(jumpForce);
    }

}
