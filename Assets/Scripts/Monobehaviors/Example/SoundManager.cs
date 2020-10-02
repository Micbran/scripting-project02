﻿using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager<SoundManager>
{
    public List<SoundFXDefinition> SoundFX;
    public AudioSource SoundFXSource;

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        SoundFXSource.PlayOneShot(effect);
    }
}
