using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] AudioSource musicSource;

    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume;

    void Start()
    {
        if (musicSource != null) musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource != null) musicSource.Stop();
    }

    public void PauseMusic()
    {
        if (musicSource != null) musicSource.Pause();
    }

    public void ResumeMusic()
    {
        if (musicSource != null) musicSource.UnPause();
    }

    public void PlayShootingSFX()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageSFX()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

}
