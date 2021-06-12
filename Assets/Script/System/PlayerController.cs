using UnityEngine;

namespace Script.System
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 7f;
        [SerializeField] private float _jumpHeight = 3f;

        [SerializeField] [Tooltip("設定可以跳幾下。設定2為雙重跳。設定0為無限跳....？")]
        private int _jumpTimeLimit = 2;

        private CharacterController _controller;

        private int _hasJumped;
        private float gravityConstant;
        private Vector3 gravityVelocity;

        // Start is called before the first frame update
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            gravityConstant = Physics.gravity.magnitude;
        }

        // Update is called once per frame
        private void Update()
        {
            var hDirection = Input.GetAxis(Constants.Input.Horiznotal);
            var vDirection = Input.GetAxis(Constants.Input.Vertical);
            var movingVelocity = (Vector3.right * hDirection + Vector3.forward * vDirection) * _moveSpeed;

            if (Input.GetButtonDown(Constants.Input.Jump))
            {
                if (_controller.isGrounded || _hasJumped < _jumpTimeLimit || _jumpTimeLimit == 0)
                {
                    gravityVelocity = Mathf.Sqrt(_jumpHeight * 2 * gravityConstant) * -Physics.gravity.normalized;
                    _hasJumped++;
                }
            }
            else
            {
                gravityVelocity = _controller.isGrounded
                    ? Vector3.zero
                    : gravityVelocity + Physics.gravity * Time.deltaTime;
                if (_controller.isGrounded) _hasJumped = 0;
            }

            movingVelocity += gravityVelocity;

            _controller.Move(movingVelocity * Time.deltaTime);
        }
    }
}