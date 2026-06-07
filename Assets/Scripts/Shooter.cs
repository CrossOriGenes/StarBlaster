using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = .2f;

    [Header("AI Variables")]
    [SerializeField] bool useAI;
    [SerializeField] float minimumFireRate = .2f;
    [SerializeField] float fireRateVariance = 0f;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null) 
            fireCoroutine = StartCoroutine(FireContinuously());
        else if (!isFiring && fireCoroutine != null) {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectileObject = Instantiate(
                projectilePrefab, 
                transform.position, 
                Quaternion.identity
            );

            projectileObject.transform.rotation = transform.rotation;
            Rigidbody2D projectileRB = projectileObject.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectileObject, projectileLifetime);
            yield return new WaitForSeconds(RandomDelay());
        }
    }

    private float RandomDelay()
    {
        float waitTime = Random.Range(
            baseFireRate - fireRateVariance,
            baseFireRate + fireRateVariance
        );
        waitTime = Mathf.Clamp(waitTime, minimumFireRate, float.MaxValue);

        return waitTime;
    }
}
