using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Crossbow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Rigidbody2D bolt;
    [SerializeField] float fireVelocity;

    [SerializeField] private AudioSource crossbowSFX;
    public void OnPointerClick(PointerEventData eventData)
    {
        Trigger();
    }

    void Trigger()
    {
        Instantiate(bolt, transform.position, transform.rotation).velocity = transform.up * fireVelocity;
        crossbowSFX.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
