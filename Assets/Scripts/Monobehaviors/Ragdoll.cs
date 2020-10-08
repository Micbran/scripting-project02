using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody ragdollCore = null;
    [SerializeField] private float timeToLive = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    public void ApplyForce(Vector3 force)
    {
        ragdollCore.AddForce(force);
        
        ragdollCore.AddTorque(new Vector3(force.x * Random.Range(0.1f, 10f), force.y * Random.Range(0.1f, 10f), force.z * Random.Range(0.1f, 10f)));
    }
}
