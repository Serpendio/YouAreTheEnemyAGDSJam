using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppingObj : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private AudioSource DroppingSFX;

    public void OnPointerClick(PointerEventData eventData)
    {
        Trigger();
    }

    void Trigger()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        DroppingSFX.Play();
    }

    private void Awake()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
