using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action GroundCollide = delegate { };
    public event Action GroundLeft = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        GroundCollide.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        GroundLeft.Invoke();
    }
}
