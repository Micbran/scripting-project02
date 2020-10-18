using UnityEngine;

public class DestructibleGivePoints : MonoBehaviour, IDestructible 
    // horrendously unscalable, alternate solution with events and publisher/subscriber pattern suggested
{
    [SerializeField] private int pointValue = 10;

    private Level01Controller controller = null;

    private void Awake()
    {
        controller = FindObjectOfType<Level01Controller>();    
    }

    public void OnDestruction(GameObject destroyer)
    {
        controller.IncreaseScore(pointValue);
    }
}
