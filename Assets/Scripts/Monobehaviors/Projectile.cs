using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifeTimeAfterHit;
    private float projectileSpeed;
    private float range;
    private float damage;
    private float distanceTravelled;
    private GameObject shooter;
    private Vector3 travelDirection;
    private Rigidbody rb;
    private bool targetHit;

    public void Fire(GameObject sh, Vector3 t, float s, float r, float d, float life)
    {
        shooter = sh;
        projectileSpeed = s;
        range = r;
        damage = d;
        lifeTimeAfterHit = life;
        travelDirection = t - transform.position;
        travelDirection.y = 0f;
        travelDirection.Normalize();

        distanceTravelled = 0f;

        rb = gameObject.GetComponent<Rigidbody>();
        targetHit = false;

    }

    private void Update()
    {
        if(targetHit)
            return;

        float distanceToTravel = projectileSpeed * Time.deltaTime;

        transform.Translate(travelDirection * distanceToTravel);

        distanceTravelled += distanceToTravel;
        if (distanceTravelled > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(targetHit)
            return;

        if(collision.gameObject == shooter)
            return;

        targetHit = true;
        var hittables = collision.gameObject.GetComponents(typeof(IHittable));
        foreach (IHittable h in hittables)
        {
            h.OnHit(gameObject, damage); // TODO put damage numbers somewhere
        }
        if (rb != null)
        {
            rb.useGravity = true;
            rb.AddExplosionForce(100f, collision.GetContact(0).point, 1f);
        }
        Destroy(gameObject, lifeTimeAfterHit);
    }
}
