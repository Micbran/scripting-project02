using UnityEngine;

public class HealthPackPickup : MonoBehaviour
{
    [SerializeField] private float healthToHeal = 10;

    private void OnTriggerEnter(Collider other)
    {
        ActorStats stats = other.gameObject.GetComponent<ActorStats>();

        if(stats != null)
        {
            if (stats.Health == stats.MaxHealth)
                return;

            stats.TakeDamage(-healthToHeal);
            AudioManager.Instance.PlaySoundEffect(SoundEffect.Pickup);
            Destroy(gameObject);
        }
    }
}
