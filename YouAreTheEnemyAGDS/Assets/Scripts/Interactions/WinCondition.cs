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
    private float MaxLevel = 2;
    public static Action OnDoorEntered;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || isLocked) return;
        OnDoorEntered?.Invoke();    
    }

    public void SceneChange()
    {
        if (LevelCount<MaxLevel)
            StartCoroutine("NextLevel");
        else
            Debug.Log("PLAYER WON!");
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelCount++;
    }

}
