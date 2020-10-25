using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform playerFacingTransform = null;
    [SerializeField] private Transform endOfBarrel = null;
    [SerializeField] private float turnSpeed = 60f;
    [SerializeField] private float shootRange = 5f;
    [SerializeField] private float seekRange = 10f;
    [SerializeField] private Projectile_SO projectile = null;

    private Transform mainTransform;
    private Transform playerTransform;
    private float attackCooldownTimer;
    
    private void Awake()
    {
        mainTransform = gameObject.GetComponent<Transform>();
        attackCooldownTimer = 0;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        attackCooldownTimer -= Time.deltaTime;

        if(playerTransform != null)
        {
            float distanceFromPlayer = Vector3.Distance(mainTransform.position, playerTransform.position);
            bool attackOffCooldown = attackCooldownTimer <= 0;

            if(distanceFromPlayer <= seekRange)
            {
                playerFacingTransform.LookAt(playerTransform);
                mainTransform.rotation = Quaternion.RotateTowards(mainTransform.rotation, playerFacingTransform.rotation, turnSpeed * Time.deltaTime);
                // "lock" rotation to two axes
                Quaternion lockedRotation = mainTransform.rotation;
                // lockedRotation.x = 0;
                // lockedRotation.z = 0;
                mainTransform.rotation = lockedRotation;
            }

            if (attackOffCooldown && (distanceFromPlayer <= shootRange))
            {
                attackCooldownTimer = projectile.projectileCooldown;
                ShootProjectile();
                AudioManager.Instance.PlaySoundEffect(SoundEffect.EnemyFire);
            }
        }
    }

    private void ShootProjectile()
    {
        Projectile bullet = Instantiate(projectile.projectileToFire, endOfBarrel.position, Quaternion.identity);
        bullet.Fire(gameObject, playerTransform.position, projectile.projectileSpeed, projectile.projectileRange, projectile.projectileDamage, projectile.lifeTimeAfterHit);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seekRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
