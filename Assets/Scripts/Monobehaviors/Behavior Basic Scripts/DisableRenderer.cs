using UnityEngine;

public class DisableRenderer : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
