using UnityEngine;

public class DestructibleRagdoll : MonoBehaviour, IDestructible
{
    [SerializeField] private Ragdoll ragdollObject = null;
    [SerializeField] private float force = 1f;
    [SerializeField] private float lift = 1f;

    public void OnDestruction(GameObject destroyer)
    {
        Ragdoll ragdoll = Instantiate(ragdollObject, transform.position, transform.rotation);

        Vector3 vectorFromDestroyer = transform.position - destroyer.transform.position;
        vectorFromDestroyer.Normalize();
        vectorFromDestroyer.y += lift;

        ragdoll.ApplyForce(vectorFromDestroyer * force);
    }
}
