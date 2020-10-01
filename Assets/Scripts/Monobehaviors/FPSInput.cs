using System;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] bool invertVertical = false;

    public event Action<Vector3> MoveInput = delegate { };
    public event Action<Vector3> RotateInput = delegate { };
    public event Action JumpInput = delegate { };

    void Update()
    {
        DetectMoveInput();
        DetectRotateInput();
        DetectJumpInput();
    }

    private void DetectMoveInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        if(xInput != 0 || zInput != 0)
        {
            Vector3 horizontalMovement = transform.right * xInput;
            Vector3 forwardMovement = transform.forward * zInput;

            Vector3 totalMovement = (horizontalMovement + forwardMovement).normalized;

            MoveInput.Invoke(totalMovement);

        }
    }

    private void DetectRotateInput()
    {
        float xInput = Input.GetAxisRaw("Mouse X");
        float yInput = Input.GetAxisRaw("Mouse Y");

        if(xInput != 0 || yInput != 0)
        {
            yInput = invertVertical ? -yInput : yInput;

            Vector3 rotation = new Vector3(yInput, xInput, 0);

            RotateInput.Invoke(rotation);
        }
    }

    private void DetectJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput.Invoke();
        }
    }
}
