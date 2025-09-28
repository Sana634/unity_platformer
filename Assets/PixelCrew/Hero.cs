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
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;

        [SerializeField] private LayerCheck _groundCheck;

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void SetDirection(Vector2 movement)
        {
            _movement = movement;
        }

        public void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_movement.x * _speed, _rigidbody.velocity.y);

            var isJumping = _movement.y > 0.5f;
            if (isJumping)
            {
                if (IsGrounded() && _rigidbody.velocity.y <= 0)
                {
                    _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
                else if (_rigidbody.velocity.y > 0)
                {
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
                }
            }
        }

        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;

        }

        private void OnDrawGizmos()
        {
            //Debug.DrawRay(start: transform.position, dir: Vector3.down, color: IsGrounded() ? Color.green : Color.red);
            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position, 0.1f);

        }

        public void SaySomething()
        {
            Debug.Log("Something!");
        }
    }
}