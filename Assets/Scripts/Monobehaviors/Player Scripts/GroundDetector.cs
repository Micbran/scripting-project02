using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action GroundCollide = delegate { };
    public event Action GroundLeft = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Enemy"))
            GroundCollide.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Enemy"))
            GroundLeft.Invoke();
    }
}
