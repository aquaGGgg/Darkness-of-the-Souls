using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _dashDistance = 3f;

    [SerializeField]
    private LayerMask _collisionMask; // Маска для определения препятствий

    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector3 _defaultScale;
    private bool _isGrounded;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _defaultScale = transform.localScale;

        Collider2D myCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(myCollider, myCollider);
    }

    void Update()
    {
        //////////////////////////////////////////////////////////////////////////
        //ходьба
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
        ///////////////////////////////////////////////////////////////////////////////////
        // деш
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash(horizontalInput);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        // прыжок
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    private void Dash(float direction) 
    {

        Vector2 dashDirection = new Vector2(Mathf.Sign(direction), 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, _dashDistance, _collisionMask);

        if (hit.collider.gameObject.CompareTag("Wall"))
        {
            Debug.Log(hit.collider.gameObject);
            // Если есть стена, рывок до стены
            transform.position = new Vector3(hit.point.x - Mathf.Sign(direction) * 0.1f, transform.position.y, transform.position.z);
        }
        else
        {
            Debug.Log("asd");
            // Если путь свободен, выполняем полный рывок
            transform.position += new Vector3(dashDirection.x * _dashDistance, 0, 0);
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
