using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform rayOrigin = null;
    private RaycastHit objectHit;
    // Start ray from barrel end, in direction of camera

    public void Shoot()
    {
        Vector3 rayDirection = playerCamera.transform.forward;



        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, 10f))
        {
            var hittables = objectHit.collider.GetComponents(typeof(IHittable));
            foreach(IHittable h in hittables)
            {
                h.OnHit(gameObject, 10f); // TODO put damage numbers in somewhere
            }
        }
        else
        {
            Debug.Log("Miss!");
        }
    }
}
