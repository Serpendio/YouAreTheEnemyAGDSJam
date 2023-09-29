using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] UnityEvent actionOnEnter;
    [SerializeField] bool triggerOneShot;
    bool hasTripped;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(triggerOneShot && hasTripped) && collision.collider.CompareTag("Player")) 
        { 
            actionOnEnter.Invoke(); 
            hasTripped = true;            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(triggerOneShot && hasTripped) && collision.CompareTag("Player")) 
        { 
            actionOnEnter.Invoke(); 
            hasTripped = true; 
        }
    }
}
