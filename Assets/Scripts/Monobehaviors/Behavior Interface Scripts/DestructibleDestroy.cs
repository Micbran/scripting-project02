using UnityEngine;

public class DestructibleDestroy : MonoBehaviour, IDestructible
{
    public void OnDestruction(GameObject destroyer)
    {
        Destroy(gameObject);
    }
}
