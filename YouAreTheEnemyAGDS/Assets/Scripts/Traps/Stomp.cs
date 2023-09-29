using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stomp : MonoBehaviour, ITrapBase
{
    [SerializeField] float maxDist, crushSpeed;
    [SerializeField] Transform crusher;
    bool isTriggered, isReturning;
    float t;

    [SerializeField] private AudioSource StompSFX;

    public void Trigger(bool byGhost = true)
    {
        if (isTriggered) return;

        isTriggered = true;
        isReturning = false;
        StompSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered) 
        {
            if (!isReturning)
                t += Time.deltaTime * crushSpeed / maxDist;
            else
                t -= Time.deltaTime * crushSpeed / maxDist / 5f;
            crusher.localPosition = Vector2.down * Mathf.Lerp(0.5f, maxDist + 0.5f, t);

            if (t >= 1f) isReturning = true;
            else if (t <= 0f) isTriggered = false;
        }
    }
}
