using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBase : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] float minSpeed = 1f; // ok yeah this doesn't work as player can push faster than this
    bool hasHit;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    protected void HitPlayer()
    {
        LevelController.Instance.HitPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && rig.velocity.sqrMagnitude > minSpeed*minSpeed && !hasHit)
        {
            HitPlayer();
            hasHit = true;
        }
    }
}
