using UnityEngine;

public interface IHittable
{
    void OnHit(GameObject attacker, float damage);
}
