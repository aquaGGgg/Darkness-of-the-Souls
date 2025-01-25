using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public static event Action<int> UnlockScill;
    public static event Action Rest;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _dashDistance = 3f;

    [SerializeField]
    private LayerMask _collisionMask; // Маска для определения препятствий

    [SerializeField]
    private int _BigSoils; // число выбитых больших душь


    [SerializeField]
    private int _SmallSoils; // число больших душь

    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector3 _defaultScale;
    private bool _isGrounded;

    private bool _SoulEating = false; // флаг для избежания дввайного вызова UnlockScill

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _defaultScale = transform.localScale;

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

        if (hit.collider != null)
        {
            // Если есть стена, рывок до стены
            transform.position = new Vector3(hit.point.x - Mathf.Sign(direction) * 0.1f, transform.position.y, transform.position.z);
        }
        else
        {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BigSoul") && _SoulEating == false)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                _SoulEating = true;
                Destroy(collision.gameObject);
                UnlockScill(_BigSoils);
                _BigSoils++;
                Invoke("restEating", 1f);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                _SoulEating = true;
                Destroy(collision.gameObject);
                UnlockScill(_BigSoils + 7);
                _BigSoils++;
                Invoke("restEating", 1f);
            }
            else if (Input.GetKeyUp(KeyCode.R)) // уничтожение большой души
            {
                _SoulEating = true;
                Destroy(collision.gameObject);
                _BigSoils++;
                Invoke("restEating", 1f);
            }

        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            if (Input.GetKeyUp(KeyCode.E))
                Rest?.Invoke();
        }
    }

    private void restEating()
    {
        _SoulEating = false;
    }
    

}