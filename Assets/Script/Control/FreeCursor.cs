using UnityEngine;

namespace Script.Control {
    public class FreeCursor : MonoBehaviour {
        private void OnEnable() {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}