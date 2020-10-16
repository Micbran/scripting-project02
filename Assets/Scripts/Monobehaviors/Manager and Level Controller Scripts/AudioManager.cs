using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Manager<AudioManager>
{
    public List<SoundFXDefinition> SoundFX;

    private AudioSource audioSource;

    [SerializeField] private AudioClip startingSong = null;

    public override void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.PlaySong(startingSong);
    }

    private void PlaySong(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        AudioClip effect = SoundFX.Find(sfx => sfx.effect == soundEffect).clip;
        audioSource.PlayOneShot(effect, 0.8f);
    }
}
