using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform rayOrigin = null;
    [SerializeField] private ParticleSystem hitParticles = null;

    private RaycastHit objectHit;

    public void Shoot()
    {
        Vector3 rayDirection = playerCamera.transform.forward;

        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, 50f))
        {
            var hittables = objectHit.collider.GetComponents(typeof(IHittable));
            foreach(IHittable h in hittables)
            {
                h.OnHit(gameObject, 10f); // TODO put damage numbers in somewhere
            }
            Instantiate(hitParticles, objectHit.point, Quaternion.LookRotation(objectHit.normal, Vector3.up));
        }
    }
}
