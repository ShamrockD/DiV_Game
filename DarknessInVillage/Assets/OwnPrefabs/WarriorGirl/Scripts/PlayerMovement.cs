using UnityEngine;

namespace PlayerComponents
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundCheck;
        [SerializeField] private Vector3 _groundCheckPositionDelta;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private bool _isOnGround;

        private Vector2 _playerDirection;
        private Rigidbody2D _playerRigidBody;
        private Animator _playerAnimator;

        // AnimatorVars to string 
        private static readonly int isRunningWGAnimator = Animator.StringToHash("wgIsRunning");
        private static readonly int isOnGroundWGAnimator = Animator.StringToHash("wgIsOnGround");
        private static readonly int isVerticalVelocityWGAnimator = Animator.StringToHash("wgVerticalVelocity");


        private void Awake()
        {
            _playerRigidBody = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            _isOnGround = GroundChecker();
        }

        private void FixedUpdate()
        {
            var xVelocity = _playerDirection.x * _speed;
            var yVelocity = CalcYVelocity();

            _playerRigidBody.velocity = new Vector2(xVelocity, yVelocity);

            AnimatorControlling();

            UpdateCharacterDirection();
        }

        private void AnimatorControlling()
        {
            //animator part
            _playerAnimator.SetBool(isRunningWGAnimator, _playerDirection.x != 0);
            _playerAnimator.SetBool(isOnGroundWGAnimator, _isOnGround);
            _playerAnimator.SetFloat(isVerticalVelocityWGAnimator, _playerRigidBody.velocity.y);
        }

        // Проверка: стоит ли игрок на земле?

        private bool GroundChecker()
        {
            var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundCheck);
            //Debug.Log(hit.collider);
            return hit.collider != null;
        }

        // Направление движения

        public void SetDirectionMove(Vector2 directionToMove)
        {
            _playerDirection = directionToMove;
        }

        // Проверка направления игрока

        private void UpdateCharacterDirection()
        {
            if (_playerDirection.x > 0)
            {
                Debug.Log(_playerDirection.x);
                transform.localScale = new Vector3(1, 1, 1); // Аналог этой записи Vector3.one
            }
            else if (_playerDirection.x < 0)
            {
                Debug.Log(_playerDirection.x);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        // Расчет прыжка

        private float CalcYVelocity()
        {
            var yVelocity = _playerRigidBody.velocity.y;
            var isJumpPressed = _playerDirection.y > 0;

            if (isJumpPressed)
            {
                yVelocity = CalcJumping(yVelocity);
            }

            else if (_playerRigidBody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalcJumping(float yVelocity)
        {
            var isJumpPressed = _playerDirection.y > 0;

            if (_isOnGround)
            {
                yVelocity += _jumpForce;
            }

            return yVelocity;
        }
    }
}


