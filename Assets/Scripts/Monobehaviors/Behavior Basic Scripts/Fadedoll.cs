using UnityEngine;

public class Fadedoll : MonoBehaviour
{
    [SerializeField] private float timeToLive = 3f;
    private MeshRenderer objMeshRenderer = null;
    private Color finalColor = Color.white;

    private void Start()
    {
        objMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        finalColor = objMeshRenderer.material.color;
        finalColor.a = 0;
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        objMeshRenderer.material.color = Color.Lerp(objMeshRenderer.material.color, finalColor, timeToLive * Time.deltaTime);
    }
}
