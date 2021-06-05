using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.System
{
    public class LevelManager : MonoBehaviour
    {
        public float progress = 0;

        private void LateUpdate()
        {
            if (progress >= 100)
            {
                Debug.Log("Finished level.");
                SceneManager.LoadSceneAsync(Constants.LevelScene.MainScene);
            }
        }

        public void AddProgress(float add)
        {
            progress += add;
        }
    }
}