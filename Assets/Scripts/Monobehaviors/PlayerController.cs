using System;
using UnityEngine;

[RequireComponent(typeof(FPSInput))]
[RequireComponent(typeof(FPSMotor))]
[RequireComponent(typeof(ActorStats))]
public class PlayerController : MonoBehaviour
{
    public event Action OnPlayerDeath = delegate { };

    private FPSInput input = null;
    private FPSMotor motor = null;
    private ActorStats stats = null;
    private FireWeapon fire = null;

    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float sprintMoveSpeed = 0.2f;
    [SerializeField] private float turnSpeed = 6f;
    [SerializeField] private float sprintTurnSpeed = 2f;
    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private ParticleSystem muzzleFlash = null; // Seriously consider moving this to different place

    private float currentMoveSpeed;
    private float currentTurnSpeed;

    #region Monobehaviour Methods

    private void Awake()
    {
        input = GetComponent<FPSInput>();
        motor = GetComponent<FPSMotor>();
        stats = GetComponent<ActorStats>();
        fire = GetComponent<FireWeapon>();

        currentMoveSpeed = moveSpeed;
        currentTurnSpeed = turnSpeed;
    }

    private void OnEnable()
    {
        input.MoveInput += OnMove;
        input.RotateInput += OnRotate;
        input.JumpInput += OnJump;
        input.SprintPressed += OnSprintStart;
        input.SprintReleased += OnSprintEnd;
        input.ShootPressed += OnShoot;
        stats.PlayerDied += OnDeath;
    }

    private void OnDisable()
    {
        input.MoveInput -= OnMove;
        input.RotateInput -= OnRotate;
        input.JumpInput -= OnJump;
        input.SprintPressed -= OnSprintStart;
        input.SprintReleased -= OnSprintEnd;
        input.ShootPressed -= OnShoot;
        stats.PlayerDied -= OnDeath;
    }

    #endregion

    #region Callbacks

    private void OnMove(Vector3 movement)
    {
        motor.Move(movement * currentMoveSpeed);
    }

    private void OnRotate(Vector3 rotation)
    {
        motor.Turn(rotation.y * currentTurnSpeed);
        motor.Look(rotation.x * currentTurnSpeed);
    }

    private void OnJump()
    {
        motor.Jump(jumpForce);
    }

    private void OnSprintStart()
    {
        currentMoveSpeed = sprintMoveSpeed;
        currentTurnSpeed = sprintTurnSpeed;
    }

    private void OnSprintEnd()
    {
        currentMoveSpeed = moveSpeed;
        currentTurnSpeed = turnSpeed;
    }

    private void OnShoot()
    {
        muzzleFlash.Play();
        fire.Shoot();
        AudioManager.Instance.PlaySoundEffect(SoundEffect.Shoot);
    }

    private void OnDeath()
    {
        OnPlayerDeath.Invoke();
    }

    #endregion
}
