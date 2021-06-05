using UnityEngine;

namespace Script.System
{
    public class GameManager : MonoBehaviour
    {
        public void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}
