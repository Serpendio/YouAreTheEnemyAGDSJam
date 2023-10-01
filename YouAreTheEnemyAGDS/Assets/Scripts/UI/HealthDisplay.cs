using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] RectTransform display, damageDisplay;
    [SerializeField] float widthPerHealth;

    void Start()
    {
        LevelController.Instance.OnPlayerHealthChanged += UpdateHealthView;
        UpdateHealthView(3);
    }

    private void UpdateHealthView(int health)
    {
        display.sizeDelta = new(health * widthPerHealth, widthPerHealth);
        damageDisplay.sizeDelta = new((3 - health) * widthPerHealth, widthPerHealth);
    }
}
