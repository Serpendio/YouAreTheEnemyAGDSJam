using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] Sprite unlockedSprite;

    bool isLocked = true;

    public void Unlock()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        isLocked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLocked)
            print("Escapist Won!");
    }

}
