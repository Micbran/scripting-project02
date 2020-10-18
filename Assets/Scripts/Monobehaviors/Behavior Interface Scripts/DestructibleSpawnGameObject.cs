using UnityEngine;

public class DestructibleSpawnGameObject : MonoBehaviour, IDestructible
{
    [SerializeField] GameObject objectToSpawn = null;

    public void OnDestruction(GameObject destroyer)
    {
        Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
    }
}
