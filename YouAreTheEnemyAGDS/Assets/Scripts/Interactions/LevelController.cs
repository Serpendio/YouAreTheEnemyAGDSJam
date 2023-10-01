using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    [SerializeField] public GameObject player;
    private int playerHealth = 3;

    public event Action<int> OnPlayerHealthChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void HitPlayer()
    {
        playerHealth--;
        OnPlayerHealthChanged(playerHealth);
    }
}
