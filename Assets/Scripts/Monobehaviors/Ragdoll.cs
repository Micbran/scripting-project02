using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody ragdollCore = null;
    [SerializeField] private float timeToLive = 3f;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    public void ApplyForce(Vector3 force)
    {
        ragdollCore.AddForce(force);
        
        ragdollCore.AddTorque(RandomExtensions.RandomVector3(0, 33f));
    }
}
