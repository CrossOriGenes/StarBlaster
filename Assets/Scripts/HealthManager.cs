using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            audioManager.PlayDamageSFX();
            damageDealer.Hit();
            if (applyCameraShake) cameraShake.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            if (gameObject.CompareTag("Enemy"))
            {
                int score = scoreKeeper.GetScore();
                score += 50;
                scoreKeeper.SetScore(score);
            }
            Destroy(gameObject);
            if (gameObject.CompareTag("Player")) Die();
        }
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void Die()
    {
        Time.timeScale = 0f;
        cameraShake.Stop();
        audioManager.StopAllCoroutines();
        // Show game over screen
        print("Game Over");
    }
}
