using System.Collections;
using UnityEngine;

public class DoubleScorePickup : MonoBehaviour
{
    [SerializeField] private float powerupTime = 10f;
    [SerializeField] private GameObject artPortion = null;

    private Level01Controller levelController = null;
    private Collider colliderToDeactivate = null;

    private void Awake()
    {
        // insanely illegal method because i don't feel like working with events LOL
        levelController = FindObjectOfType<Level01Controller>();
        colliderToDeactivate = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ActorStats stats = other.gameObject.GetComponent<ActorStats>();

        if (stats != null && stats.IsPlayer)
        {
            AudioManager.Instance.PlaySoundEffect(SoundEffect.Pickup);
            StartCoroutine(DoubleScoreEffect());
        }
    }

    private IEnumerator DoubleScoreEffect()
    {
        levelController.ActivateDoubleScorePower(powerupTime);
        DisableRendering();

        yield return new WaitForSeconds(powerupTime);

        levelController.DeactiveDoubleScorePower();
        Destroy(gameObject);
    }

    private void DisableRendering()
    {
        artPortion.SetActive(false);
        colliderToDeactivate.enabled = false;
    }
}
