using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuObject;
    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] GameObject resume;

    bool levelEnded = false;

    private void Start()
    {
        LevelController.Instance.OnLevelEnded += LevelEnd;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
       // movement = context.ReadValue<float>();
        TogglePauseMenu();

    }
    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log("PauseMenu");
        TogglePauseMenu();
    }

    private void LevelEnd()
    {
        text.text = LevelController.Instance.playerWon == true ? "King Wins" : "Ghost Wins";
        
        levelEnded = true;
        resume.SetActive(false);

        TogglePauseMenu(true);
    }

    public void TogglePauseMenu(bool overridePause = false, bool shouldResume = false)
    {
        Debug.Log("PauseMenu");

        if (!overridePause && levelEnded) return;

        if (PauseMenuObject.activeSelf && !(overridePause && shouldResume))
        {
            Time.timeScale = 1f;
            PauseMenuObject.SetActive(false);
            return;
        }
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void TogglePause()
    {
        TogglePauseMenu();
    }
}

