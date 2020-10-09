using UnityEngine;

public class DestructibleFadedoll : MonoBehaviour, IDestructible
{
    [SerializeField] private Fadedoll fadedollObject = null;

    public void OnDestruction(GameObject destroyer)
    {
        Instantiate(fadedollObject, transform.position, transform.rotation);
    }
}
