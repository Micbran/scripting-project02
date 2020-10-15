using UnityEngine;

[CreateAssetMenu(fileName = "Projectile.asset", menuName = "Projectile")]
public class Projectile_SO : ScriptableObject
{
    public float projectileCooldown;
    public float projectileRange;
    public float projectileDamage;
    public float projectileSpeed;

    public float lifeTimeAfterHit;
    public Projectile projectileToFire;

}
