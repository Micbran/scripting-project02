using UnityEngine;

public class HittableDestroy : MonoBehaviour, IHittable
{
    public void OnHit(GameObject attacker, float damage)
    {
        var destructibles = gameObject.GetComponents(typeof(IDestructible));
        foreach (IDestructible d in destructibles)
        {
            d.OnDestruction(attacker);
        }
    }
}
