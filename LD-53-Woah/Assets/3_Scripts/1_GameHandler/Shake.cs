using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeMagnitude;
    private Vector3 startPos;
    void Start()
    {
        //CallShake(shakeDuration, shakeMagnitude);
        startPos = transform.localPosition;
    }

    public void CallShake(float duration, float magnitude)
    {
        StartCoroutine(ShakeThis(duration, magnitude));
    }

    public IEnumerator ShakeThis(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void StopShake()
    {
        StopAllCoroutines();
        transform.localPosition = startPos;
    }
}
