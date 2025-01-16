using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 5f; // Длина маршрута патрулирования
    [SerializeField] private float aggroRadius = 2f;    // Радиус агра на игрока
    [SerializeField] private Transform player;         // Ссылка на объект игрока
    [SerializeField] private float stopDistance = 1f;  // Расстояние остановки от игрока
    [SerializeField] private int speed;                // Скорость движения моба

    private Vector2 _leftPatrolPoint;
    private Vector2 _rightPatrolPoint;
    private Vector2 _targetPosition;
    private Animator _animator;

    private void Start()
    {
        Vector2 startPosition = transform.position;
        _leftPatrolPoint = startPosition - Vector2.right * patrolDistance / 2f;
        _rightPatrolPoint = startPosition + Vector2.right * patrolDistance / 2f;
        _targetPosition = _rightPatrolPoint;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("attack") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            UpdateAnimation();
            return;
        }

        Vector2 playerPosition = player.position;
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

        if (distanceToPlayer <= aggroRadius * 2)
        {
            _targetPosition = distanceToPlayer > stopDistance ? playerPosition : transform.position;
            FlipTowards(playerPosition);
        }
        else
        {
            Patrol();
        }

        MoveToTarget();
        UpdateAnimation();

    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, _targetPosition) <= 0.1f)
        {
            _targetPosition = _targetPosition == _leftPatrolPoint ? _rightPatrolPoint : _leftPatrolPoint;
        }
        FlipTowards(_targetPosition);
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
        bool isMoving = !(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("attack") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) && Vector2.Distance(transform.position, _targetPosition) > 0.05f;
        _animator.SetBool("IsWalking", isMoving);
    }
}
