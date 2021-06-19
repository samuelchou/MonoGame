using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.System {
    public class GameManager : MonoBehaviour {
        public void ChangeScene(string sceneName) {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void QuitGame() {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}