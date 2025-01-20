using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 5f; // ����� �������� ��������������
    [SerializeField] private float aggroRadius = 2f;    // ������ ���� �� ������
    [SerializeField] private Transform player;         // ������ �� ������ ������
    //[SerializeField] private float stopDistance = 1f;  // ���������� ��������� �� ������
    [SerializeField] private int speed;                // �������� �������� ����
    [SerializeField] private LayerMask visionMask;     // ����� ��� ����������� ��������� ������

    private Vector2 _leftPatrolPoint, _rightPatrolPoint, _targetPosition;
    private Animator _animator;

    private void Start()
    {
        _leftPatrolPoint = (Vector2)transform.position - Vector2.right * patrolDistance / 2f;
        _rightPatrolPoint = (Vector2)transform.position + Vector2.right * patrolDistance / 2f;
        _targetPosition = _rightPatrolPoint;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("attack") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) return;

        Vector2 playerPosition = player.position;
        if (Vector2.Distance(transform.position, playerPosition) <= aggroRadius * 2 && CanSeePlayer(playerPosition))
        {
            _targetPosition = new Vector2(playerPosition.x, transform.position.y);
        }
        else if (Vector2.Distance(transform.position, _targetPosition) <= 0.1f)
        {
            _targetPosition = _targetPosition == _leftPatrolPoint ? _rightPatrolPoint : _leftPatrolPoint;
        }
        
        FlipTowards(_targetPosition);
        MoveToTarget();
        UpdateAnimation();

    }

    private bool CanSeePlayer(Vector2 playerPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerPosition - (Vector2)transform.position).normalized, aggroRadius, visionMask);
        return hit.collider != null && hit.collider.CompareTag("Player");
    }


    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * speed);
    }

    private void FlipTowards(Vector2 targetPosition)
    {
        float directionX = targetPosition.x - transform.position.x;
        if (Mathf.Abs(directionX) > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Sign(directionX) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void UpdateAnimation()
    {
        _animator.SetBool("IsWalking", Vector2.Distance(transform.position, _targetPosition) > 0.05f);
    }
}
