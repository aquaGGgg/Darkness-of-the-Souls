using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 5f; // Длина маршрута
    [SerializeField] private float aggroRadius = 2f;    // Радиус агра
    [SerializeField] private Transform player;         // Ссылка на игрока
    [SerializeField] private float stopDistance = 1f;  // Расстояние остановки от игрока

    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private bool _isAggroed;
    private bool _returningToPatrol;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Vector2 playerPosition = player.position;
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

        // Если возвращается на маршрут
        if (_returningToPatrol)
        {
            float patrolOffset = Mathf.PingPong(Time.time, patrolDistance) - patrolDistance / 2f;
            _targetPosition = _startPosition + Vector2.right * patrolOffset;

            if (Vector2.Distance(transform.position, _startPosition) <= 0.1f)
            {
                _returningToPatrol = false; // Завершил возвращение
            }
        }
        else
        {
            // Определение агрессии
            _isAggroed = distanceToPlayer <= aggroRadius && Vector2.Distance(_startPosition, transform.position) <= patrolDistance * 2f;

            if (_isAggroed && distanceToPlayer > stopDistance)
            {
                // Гонится за игроком
                _targetPosition = playerPosition;
            }
            else if (!_isAggroed)
            {
                _returningToPatrol = true; // Начинает возвращение на маршрут
            }
        }

        // Движение к цели
        Vector2 direction = (_targetPosition - (Vector2)transform.position).normalized;
        if (direction.x != 0)
        {
            // Разворот по направлению движения
            transform.localScale = new Vector3(Mathf.Sign(direction.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * 2f);
    }
}
