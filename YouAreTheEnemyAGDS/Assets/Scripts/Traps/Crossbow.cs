using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Crossbow : MonoBehaviour, ITrapBase
{
    [SerializeField] Rigidbody2D bolt;
    [SerializeField] float fireVelocity, cooldownTime;
    float cooldown = 0;

    [SerializeField] private AudioSource crossbowSFX;

    public void Trigger(bool byGhost = true)
    {
        if (cooldown > 0) return;
        cooldown = cooldownTime;
        Instantiate(bolt, transform.position, transform.rotation).velocity = transform.up * fireVelocity;
        crossbowSFX.Play();
    }

    private void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }
}
