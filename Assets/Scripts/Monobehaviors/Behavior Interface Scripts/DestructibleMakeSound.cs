using UnityEngine;

public class DestructibleMakeSound : MonoBehaviour, IDestructible
{
    [SerializeField] private SoundEffect soundEffectToPlay = SoundEffect.EnemyDeath;

    public void OnDestruction(GameObject destroyer)
    {
        AudioManager.Instance.PlaySoundEffect(soundEffectToPlay);
    }
}
