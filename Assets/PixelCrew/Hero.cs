using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _movement;
        private Animator _animator;
        private SpriteRenderer _sprite;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private LayerCheck _groundCheck;

        
        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
        }
        public void SetDirection(Vector2 movement)
        {
            _movement = movement;
        }

        public void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_movement.x * _speed, _rigidbody.velocity.y);

            var isJumping = _movement.y > 0.5f;
            var isGrounded = IsGrounded();
            if (isJumping)
            {
                //if (isGrounded && Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
                if (isGrounded && _rigidbody.velocity.y <= 0)
                {
                    _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }
            _animator.SetBool(IsGroundKey, isGrounded);
            _animator.SetBool(IsRunning, _movement.x != 0);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);

            UpdateSpriteDirection();
        }

        private void UpdateSpriteDirection()
        { 
            if (_movement.x > 0)
            {
                _sprite.flipX = false;
            }
            else if (_movement.x < 0)
            {
                _sprite.flipX = true;
            }
        }


        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
            
        }

        private void OnDrawGizmos()
        {

            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f );

        }

        public void SaySomething()
        {
            Debug.Log("Something!");
        }
    }
}