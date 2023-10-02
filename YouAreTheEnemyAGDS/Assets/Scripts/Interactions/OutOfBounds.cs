using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelController.Instance.HitPlayer();
            LevelController.Instance.HitPlayer();
            LevelController.Instance.HitPlayer();
        }
    }
}
