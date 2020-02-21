using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public AnimationCurve magnitudeCurve;
    public float shakeDuration;
    public float shakeMagnitude;

    private void Start()
    {
        
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.localPosition;
        Transform parentObject = transform.parent;

        float elapsed = 0f;

        float inverseLerp;

        while (elapsed < duration)
        {
            inverseLerp = Mathf.InverseLerp(0, duration, elapsed);
            float curveValue = magnitudeCurve.Evaluate(inverseLerp);

            float x = Random.Range(-1f, 1f) * (magnitude * curveValue);
            float y = Random.Range(-1f, 1f) * (magnitude * curveValue);

            transform.localPosition = orignalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        transform.parent = parentObject;
        transform.localPosition = orignalPosition;
    }

    //public IEnumerator Shake(float duration, float magnitude)
    //{
    //    Vector3 orignalPosition = transform.localPosition;
    //    Transform parentObject = transform.parent;

    //    float elapsed = 0f;

    //    float inverseLerp;

    //    while (elapsed < duration)
    //    {
    //        inverseLerp = Mathf.InverseLerp(0, duration, elapsed);
    //        float x = Random.Range(-1f, 1f) * (magnitude * magnitudeCurve.Evaluate(inverseLerp));
    //        float y = Random.Range(-1f, 1f) * (magnitude * magnitudeCurve.Evaluate(inverseLerp));

    //        transform.localPosition = orignalPosition + new Vector3(x, y, 0);
    //        elapsed += Time.deltaTime;
    //        yield return 0;
    //    }

    //    transform.parent = parentObject;
    //    transform.localPosition = orignalPosition;
    //}
}