using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.System {

    public class GameManager : MonoBehaviour {
        public void ChangeScene(string sceneName) {
            SceneManager.LoadSceneAsync(sceneName);
        }

        #region Pause Menu

        private bool isPaused = false;
        private bool hasloadedPauseMenu = false;
        public KeyCode pauseKey = KeyCode.Escape;

        public void TogglePause() {
            Debug.Log("isPaused is " + isPaused);
            if (!isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
            isPaused = !isPaused;
        }

        private void OpenPauseMenu() {
            Debug.Log("Open pause menu.");
            SceneManager.LoadScene(Constants.LevelScene.PauseMenu, LoadSceneMode.Additive);
            hasloadedPauseMenu = true;
        }

        public void ClosePauseMenu() {
            Debug.Log("Closing pause menu...");
            if (!hasloadedPauseMenu)
            {
                Debug.LogError("Pause Menu not loaded! Won't do anything.");
                return;
            }
            SceneManager.UnloadSceneAsync(Constants.LevelScene.PauseMenu);
            hasloadedPauseMenu = false;
        }

        # endregion

        public void RestartScene() {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame() {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}