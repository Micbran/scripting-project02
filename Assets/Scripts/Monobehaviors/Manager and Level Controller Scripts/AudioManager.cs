using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Manager<AudioManager>
{
    private readonly int MUSIC_AUDIO_SOURCE_INDEX = 1;
    private readonly int SOUND_FX_AUDIO_SOURCE_INDEX = 0;

    public List<SoundFXDefinition> SoundFX;

    private AudioSource[] audioSources;

    [SerializeField] private AudioClip startingSong = null;

    public override void Awake()
    {
        Instance = this;
        audioSources = GetComponents<AudioSource>();
    }

    private void Start()
    {
        PlaySong(startingSong);
    }

    private void PlaySong(AudioClip clip)
    {
        audioSources[MUSIC_AUDIO_SOURCE_INDEX].clip = clip;
        audioSources[MUSIC_AUDIO_SOURCE_INDEX].Play();
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        audioSources[SOUND_FX_AUDIO_SOURCE_INDEX].PlayOneShot(effect, 0.8f);
    }
}
