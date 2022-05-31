using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Coroutine lastCoroutine;

    public void Move(Vector3 ToPose)
    {
        if (lastCoroutine != null)
            StopCoroutine(lastCoroutine);

        lastCoroutine = StartCoroutine(IMove(ToPose));
    }

    public IEnumerator IMove(Vector3 ToPose)
    {
        float animateTime = 0.75f, startTime = Time.realtimeSinceStartup, fraction = 0f;
        Vector3 oldPos = transform.position;

        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / animateTime);

            transform.position = Vector3.Lerp(oldPos, ToPose, fraction);

            yield return new WaitForFixedUpdate();
        }
    }
}
