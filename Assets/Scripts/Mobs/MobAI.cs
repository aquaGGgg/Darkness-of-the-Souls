using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 5f; // ����� ��������
    [SerializeField] private float aggroRadius = 2f;    // ������ ����
    [SerializeField] private Transform player;         // ������ �� ������
    [SerializeField] private float stopDistance = 1f;  // ���������� ��������� �� ������

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

        // ���� ������������ �� �������
        if (_returningToPatrol)
        {
            float patrolOffset = Mathf.PingPong(Time.time, patrolDistance) - patrolDistance / 2f;
            _targetPosition = _startPosition + Vector2.right * patrolOffset;

            if (Vector2.Distance(transform.position, _startPosition) <= 0.1f)
            {
                _returningToPatrol = false; // �������� �����������
            }
        }
        else
        {
            // ����������� ��������
            _isAggroed = distanceToPlayer <= aggroRadius && Vector2.Distance(_startPosition, transform.position) <= patrolDistance * 2f;

            if (_isAggroed && distanceToPlayer > stopDistance)
            {
                // ������� �� �������
                _targetPosition = playerPosition;
            }
            else if (!_isAggroed)
            {
                _returningToPatrol = true; // �������� ����������� �� �������
            }
        }

        // �������� � ����
        Vector2 direction = (_targetPosition - (Vector2)transform.position).normalized;
        if (direction.x != 0)
        {
            // �������� �� ����������� ��������
            transform.localScale = new Vector3(Mathf.Sign(direction.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * 2f);
    }
}
