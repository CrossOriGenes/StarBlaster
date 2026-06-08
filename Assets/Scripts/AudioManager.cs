using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume;

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
