using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AGDS
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainMenu, creditsMenu, controlsMenu, settingsMenu, quitButton;
        void Awake()
        {
#if UNITY_WEBGL
            Destroy(quitButton);
#endif
            SwitchView(0);
        }

        public void SwitchView(int viewNum)
        {
            mainMenu.SetActive(viewNum == 0);
            settingsMenu.SetActive(viewNum == 1);
            controlsMenu.SetActive(viewNum == 2);
            creditsMenu.SetActive(viewNum == 3);
        }

        public void LoadScene()
        {
            var nextIndex = gameObject.scene.buildIndex + 1;
            var operation = SceneManager.LoadSceneAsync(nextIndex, LoadSceneMode.Additive);
            operation.completed += (op) =>
            {
                Scene next = SceneManager.GetSceneByBuildIndex(nextIndex);

                SceneManager.UnloadSceneAsync(gameObject.scene);
                SceneManager.SetActiveScene(next);
            };
        }

        public void QuitApp()
        {
            Application.Quit();
        }
    }
}
