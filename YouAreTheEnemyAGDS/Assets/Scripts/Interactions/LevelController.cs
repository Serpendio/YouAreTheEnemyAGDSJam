using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    [SerializeField] public GameObject player;
    private int playerHealth = 3;
    public bool playerWon = true;

    public event Action<int> OnPlayerHealthChanged;
    public event Action OnLevelEnded;

    private void Awake()
    {
        Instance = this;
    }

    public void EndLevel()
    {
        OnLevelEnded.Invoke();
    }

    public void HitPlayer()
    {
        playerHealth--;
        if (playerHealth == 0)
        {
            playerWon = false;
            OnLevelEnded.Invoke();
        }
        OnPlayerHealthChanged.Invoke(playerHealth);
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(0);
    }
}
