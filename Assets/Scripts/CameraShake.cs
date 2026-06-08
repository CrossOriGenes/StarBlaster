using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeIntensity = 0.5f;

    Vector3 initialCameraPosition;
    Coroutine cameraShakeCoroutine;

    void Start()
    {
        initialCameraPosition = transform.position;
    }

    public void Play()
    {
        cameraShakeCoroutine = StartCoroutine(ShakeCamera());
    }

    public void Stop()
    {
        StopCoroutine(cameraShakeCoroutine);
        transform.position = initialCameraPosition;        
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0f;
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialCameraPosition + (Vector3)Random.insideUnitCircle * shakeIntensity;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialCameraPosition;
    }
}
