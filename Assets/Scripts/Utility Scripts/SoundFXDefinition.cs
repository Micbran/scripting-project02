using UnityEngine;

[System.Serializable]
public struct SoundFXDefinition
{
    public SoundEffect effect;
    public AudioClip clip;
}

[System.Serializable]
public enum SoundEffect
{
    Shoot,
    Damaged,
    EnemyFire,
    Pickup,
    EnemyDeath,
    CrateBreak
}
