using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;

    private Rigidbody2D _rb;
    private Animator _animator;


    private Vector3 _defaultScale;
    private bool _isGrounded;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _defaultScale = transform.localScale;
    }

    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(horizontalInput * _speed, _rb.linearVelocity.y);

        if (horizontalInput != 0)
        {
            _animator.SetBool("IsGo", true);
            transform.localScale = new Vector3(_defaultScale.x * Mathf.Sign(horizontalInput), _defaultScale.y, _defaultScale.z);
        }
        else
        {
            _animator.SetBool("IsGo", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsJump", false);
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsJump", true);
            _isGrounded = false;
        }
    }


}