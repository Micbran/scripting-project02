using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    [SerializeField] private GameObject artToMove = null;
    [SerializeField] private float spinSpeed = 40f;
    [SerializeField] private float yDistance = 1f;
    [SerializeField] private float bounceTime = 0.5f;
    [SerializeField] private float delta = 0.01f;

    private Transform artTransform = null;
    private bool movingUp = true;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 positionUp;
    private Vector3 positionDown;

    private void Awake()
    {
        artTransform = artToMove.transform;

        positionUp = artTransform.position;
        positionUp.y += yDistance;

        positionDown = artTransform.position;
    }

    private void Update()
    {
        artTransform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        if(movingUp)
        {
            artTransform.position = Vector3.SmoothDamp(artTransform.position, positionUp, ref currentVelocity, bounceTime);
            movingUp = !(Mathf.Abs(artTransform.position.y - positionUp.y) < delta);
        }
        else
        {
            artTransform.position = Vector3.SmoothDamp(artTransform.position, positionDown, ref currentVelocity, bounceTime);
            movingUp = Mathf.Abs(artTransform.position.y - positionDown.y) < delta;
        }
    }
}
