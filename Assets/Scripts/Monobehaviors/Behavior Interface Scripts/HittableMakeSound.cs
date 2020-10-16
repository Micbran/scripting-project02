using UnityEngine;

public class HittableMakeSound : MonoBehaviour, IHittable
{
    [SerializeField] private SoundEffect soundToPlay = SoundEffect.Damaged;

    public void OnHit(GameObject attacker, float damage)
    {
        AudioManager.Instance.PlaySoundEffect(soundToPlay);
    }
}
