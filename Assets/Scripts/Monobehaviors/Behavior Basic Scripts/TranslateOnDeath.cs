using UnityEngine;

// this is a very terribly designed script, merely intended to solve a last minute problem and i didn't feel like using events
public class TranslateOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject triggeringObject = null;
    [SerializeField] private Transform whereToGo = null;
    [SerializeField] private float travelTime = 2f;

    private bool started = false;
    private Transform objectTransform = null;
    private Vector3 refVelo = Vector3.zero;

    private void Awake()
    {
        objectTransform = gameObject.transform;
    }

    void Update()
    {
        if(triggeringObject == null)
        {
            if(!started)
            {
                started = true;
                Destroy(gameObject, travelTime + 1);
            }
            objectTransform.position = Vector3.SmoothDamp(objectTransform.position, whereToGo.position, ref refVelo, travelTime);
        }
    }
}
