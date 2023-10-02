using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] Sprite unlockedSprite;
    static float LevelCount = 1;
    private float MaxLevel = 3;
    public static Action OnDoorEntered;

    [SerializeField] private AudioSource keyGetSFX;
    [SerializeField] private AudioSource EscapeWinSFX;

    bool isLocked = true;

    private void OnEnable()
    {
        OnDoorEntered += SceneChange;        
    }

    private void OnDisable()
    {
        OnDoorEntered -= SceneChange;
    }

    public void Unlock()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        isLocked = false;
        keyGetSFX.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || isLocked) return;
        //OnDoorEntered?.Invoke();
        EscapeWinSFX.Play();
        LevelController.Instance.EndLevel();
       
    }

    public void SceneChange()
    {
        if (LevelCount<MaxLevel)
            StartCoroutine("NextLevel");
        else
            StartCoroutine("Credits");
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelCount++;
    }

}
