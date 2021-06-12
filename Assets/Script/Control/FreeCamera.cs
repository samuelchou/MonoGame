using UnityEngine;

namespace Script.Control {
    public class FreeCamera : MonoBehaviour {
        public float cursorSensitivity = 0.025f;

        public bool cursorToggleAllowed = true;
        public KeyCode cursorToggleButton = KeyCode.Escape;

        private bool _isCursorLocked = true;

        private void Update() {
            if (cursorToggleAllowed)
                if (Input.GetKeyDown(cursorToggleButton)) {
                    _isCursorLocked = !_isCursorLocked;
                    Cursor.visible = !_isCursorLocked;
                    Cursor.lockState = _isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
                }

            if (_isCursorLocked) {
                var eulerAngles = transform.eulerAngles;
                eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
                eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;

                //"overhead" prevention
                if (eulerAngles.x > 90 && eulerAngles.x < 180) eulerAngles.x = 90;
                if (eulerAngles.x < 270 && eulerAngles.x > 180) eulerAngles.x = 270;

                //apply
                transform.eulerAngles = eulerAngles;
            }
        }

        private void OnEnable() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}