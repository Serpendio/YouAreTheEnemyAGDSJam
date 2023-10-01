using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuObject;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    TogglePauseMenu();
        //}
    }

    public void TogglePauseMenu()
    {
        Debug.Log("PauseMenu");

        if (PauseMenuObject.activeSelf)
        {
            Time.timeScale = 1f;
            PauseMenuObject.SetActive(false);
            return;
        }
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0f;

    }
}

