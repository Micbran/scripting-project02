using System;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] bool invertVertical = false;
    [SerializeField] float sprintHorizontalDivisionFactor = 4f;

    private bool isSprinting;

    public event Action<Vector3> MoveInput = delegate { };
    public event Action<Vector3> RotateInput = delegate { };
    public event Action JumpInput = delegate { };
    public event Action SprintPressed = delegate { };
    public event Action SprintReleased = delegate { };
    public event Action ShootPressed = delegate { };

    private void Awake()
    {
        isSprinting = false;
    }

    private void Update()
    {
        if(Time.timeScale != 0) // TODO fix this because it's a really bad solution to "if game is paused"
        {
            DetectMoveInput();
            DetectRotateInput();
            DetectJumpInput();
            DetectSprintInput();
            DetectShootInput();
        }
    }

    private void DetectMoveInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        if (xInput != 0 || zInput != 0)
        {
            Vector3 horizontalMovement = transform.right * xInput;
            Vector3 forwardMovement = transform.forward * zInput;

            Vector3 totalMovement;
            if(isSprinting)
            {

                totalMovement = ((horizontalMovement / sprintHorizontalDivisionFactor) + forwardMovement).normalized;

            }
            else
            {
                totalMovement = (horizontalMovement + forwardMovement).normalized;
            }

            MoveInput.Invoke(totalMovement);

        }
    }

    private void DetectRotateInput()
    {
        float xInput = Input.GetAxisRaw("Mouse X");
        float yInput = Input.GetAxisRaw("Mouse Y");

        if (xInput != 0 || yInput != 0)
        {
            yInput = invertVertical ? -yInput : yInput;

            Vector3 rotation = new Vector3(yInput, xInput, 0);

            RotateInput.Invoke(rotation);
        }
    }

    private void DetectJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput.Invoke();
        }
    }

    private void DetectSprintInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            SprintPressed.Invoke();
            return;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            SprintReleased.Invoke();
            return;
        }
    }

    private void DetectShootInput()
    {
        if(Input.GetMouseButtonDown(0)) // LORD knows why this isn't an enum. Unity Devs, wtf? LMB btw.
        {
            ShootPressed.Invoke();
        }
    }
}
