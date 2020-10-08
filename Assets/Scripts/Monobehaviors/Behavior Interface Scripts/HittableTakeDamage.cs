using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorStats))]
public class HittableTakeDamage : MonoBehaviour, IHittable
{
    private ActorStats stats;

    private void Awake()
    {
        stats = GetComponent<ActorStats>();
    }

    public void OnHit(GameObject attacker, float damage)
    {
        stats.TakeDamage(damage);

        if(stats.Health <= 0)
        {
            var destructibles = gameObject.GetComponents(typeof(IDestructible));
            foreach(IDestructible d in destructibles)
            {
                d.OnDestruction(attacker);
            }
        }
    }
}
