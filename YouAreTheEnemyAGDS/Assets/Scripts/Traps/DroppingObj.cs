using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppingObj : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Trigger();
    }

    void Trigger()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void Awake()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
