using UnityEngine;
using UnityEngine.Events;

namespace Script.System {
    public class LevelManager : MonoBehaviour {
        public float progress;
        public UnityEvent onLevelFinishEvent;

        private void LateUpdate() {
            if (progress >= 100) {
                Debug.Log("Finished level.");
                onLevelFinishEvent.Invoke();
            }
        }

        public void AddProgress(float add) {
            progress += add;
        }
    }
}