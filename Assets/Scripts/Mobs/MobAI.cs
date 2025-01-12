using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 5f; // Длина маршрута
    [SerializeField] private float aggroRadius = 2f;    // Радиус агра
    [SerializeField] private Transform player;         // Ссылка на игрока
    [SerializeField] private float stopDistance = 1f;  // Расстояние остановки от игрока
    [SerializeField] private int speed;                // Скорость моба

    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private bool _isAggroed;
    private bool _returningToPatrol;
    private Animator _animator;

    private void Start()
    {
        _startPosition = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 playerPosition = player.position;
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

        if (_returningToPatrol)
        {
            HandlePatrolReturn();
        }
        else
        {
            _isAggroed = distanceToPlayer <= aggroRadius * 2;
            if (_isAggroed) HandleAggro(playerPosition, distanceToPlayer);
            else _returningToPatrol = true;
        }

        MoveToTarget();
        _animator.SetBool("IsWalking", Vector2.Distance(transform.position, _targetPosition) > 0.01f); // Баг анимации из за слишком частого обновления таргета
    }

    private void HandlePatrolReturn()
    {
        _targetPosition = _startPosition + Vector2.right * (Mathf.PingPong(Time.time, patrolDistance) - patrolDistance / 2f);
        if (Vector2.Distance(transform.position, _startPosition) <= 0.1f) _returningToPatrol = false;
    }

    private void HandleAggro(Vector2 playerPosition, float distanceToPlayer)
    {
        _targetPosition = distanceToPlayer > stopDistance ? playerPosition : transform.position;
        FlipTowards(playerPosition);
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * speed);
        if (!_isAggroed && (_targetPosition - (Vector2)transform.position).x != 0)
            FlipTowards(_targetPosition);
    }

    private void FlipTowards(Vector2 targetPosition)
    {
        transform.localScale = new Vector3(Mathf.Sign((targetPosition - (Vector2)transform.position).x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
