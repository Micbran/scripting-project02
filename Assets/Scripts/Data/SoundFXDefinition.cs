﻿using UnityEngine;

[System.Serializable]
public struct SoundFXDefinition
{
    public SoundEffect effect;
    public AudioClip clip;
}

[System.Serializable]
public enum SoundEffect
{
    CoinCollect,
    GameOver,
    PlayerDeath,
    SpeedPowerupCollect,
    SpeedPowerupExpire,
    InvincbilityPowerupCollect,
    Win
}
