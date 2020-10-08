using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] float damage = 0.25f;

    private void OnTriggerStay(Collider collision)
    {
        ActorStats stats = collision.gameObject.GetComponent<ActorStats>();

        if(stats != null)
        {
            stats.TakeDamage(damage);
        }
    }
}
