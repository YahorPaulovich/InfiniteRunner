using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _horizontal;
    [SerializeField] private float _speed = 8f;
    private float _jumpingPower = 16f;
    private bool _isFacingRight = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals("Spike"))
        {
            Debug.Log("Spike");
        }
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
        if (!_isFacingRight && _horizontal > 0f)
        {
            Flip();
        }
        else if (_isFacingRight && _horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpingPower);
        }
        
        if (context.canceled && _rigidbody2D.velocity.y > 0f)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void MovementDirection(InputAction.CallbackContext context)
    {
        _horizontal = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()).normalized.x;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>().normalized.x);
        //_horizontal = context.ReadValue<Vector2>().normalized.x;
    }
}
