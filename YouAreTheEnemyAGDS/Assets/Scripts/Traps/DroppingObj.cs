using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppingObj : MonoBehaviour, ITrapBase
{

    [SerializeField] private AudioSource DroppingSFX;

    public void Trigger(bool byGhost = true)
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        DroppingSFX.Play();
    }

    private void Awake()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
