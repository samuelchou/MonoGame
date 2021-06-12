using UnityEngine;

namespace Script.Control {
    // FPSPlayerController by STC, 2021/06/12
    // usage: add it to your "Player" which has a child holding Camera.
    // Player Object: CharacterController, FPSPlayerController
    // > CameraHolder Object: Camera
    [RequireComponent(typeof(CharacterController))]
    public class FPSPlayerController : MonoBehaviour {
        [SerializeField] private float _moveSpeed = 7f;
        [SerializeField] private float _jumpHeight = 3f;

        [SerializeField] [Tooltip("設定可以跳幾下。設定2為雙重跳。設定0為無限跳....？")]
        private int _jumpTimeLimit = 2;

        [SerializeField] [Tooltip("滑鼠靈敏度。")] private float cursorSensitivity = 0.025f;

        public bool cursorToggleAllowed = true;
        public KeyCode cursorToggleButton = KeyCode.Escape;

        private GameObject _cameraHolder;

        private CharacterController _controller;

        private int _hasJumped;
        private bool _isCursorLocked = true;
        private float gravityConstant;
        private Vector3 gravityVelocity;

        private void Update() {
            var hDirection = Input.GetAxis("Horizontal");
            var vDirection = Input.GetAxis("Vertical");
            var transform1 = transform;
            var movingVelocity = (transform1.right * hDirection + transform1.forward * vDirection) * _moveSpeed;

            if (Input.GetButtonDown("Jump")) {
                if (_controller.isGrounded || _hasJumped < _jumpTimeLimit || _jumpTimeLimit == 0) {
                    gravityVelocity = Mathf.Sqrt(_jumpHeight * 2 * gravityConstant) * -Physics.gravity.normalized;
                    _hasJumped++;
                }
            }
            else {
                gravityVelocity = _controller.isGrounded
                    ? Vector3.zero
                    : gravityVelocity + Physics.gravity * Time.deltaTime;
                if (_controller.isGrounded) _hasJumped = 0;
            }

            movingVelocity += gravityVelocity;

            _controller.Move(movingVelocity * Time.deltaTime);

            if (cursorToggleAllowed)
                if (Input.GetKeyDown(cursorToggleButton)) {
                    _isCursorLocked = !_isCursorLocked;
                    Cursor.visible = !_isCursorLocked;
                    Cursor.lockState = _isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
                }

            if (_isCursorLocked) {
                var transformEulerAngles = transform.eulerAngles;
                var eulerAngles = _cameraHolder.transform.eulerAngles;
                eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
                transformEulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;

                //"overhead" prevention
                if (eulerAngles.x > 90 && eulerAngles.x < 180) eulerAngles.x = 90;
                if (eulerAngles.x < 270 && eulerAngles.x > 180) eulerAngles.x = 270;

                //apply
                _cameraHolder.transform.eulerAngles = eulerAngles;
                transform.eulerAngles = transformEulerAngles;
            }
        }

        private void OnEnable() {
            gravityConstant = Physics.gravity.magnitude;
            _controller = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _cameraHolder = gameObject.GetComponentInChildren<Camera>().gameObject;
        }
    }
}