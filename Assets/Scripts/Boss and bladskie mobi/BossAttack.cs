using UnityEngine;
using UnityEditor.Animations;
using Attacks;

public class BossAttack : AbstractAttack
{
    [SerializeField] private Transform player;
    [SerializeField] private Attack[] bossAttacks;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("����� �� ��������! ������� Transform ������.");
        }
    }

    public void ExecuteRandomAttack()
    {
        if (player == null) return;

        // ������������ ��������� �� ������
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // �������� ��������� �����, ������� ����� ������� ������
        var validAttacks = new System.Collections.Generic.List<Attack>();
        foreach (var attack in bossAttacks)
        {
            if (distanceToPlayer <= attack.range)
            {
                validAttacks.Add(attack);
            }
        }

        // ���� ��������� ���� ���, ������ �� ������
        if (validAttacks.Count == 0)
        {
            Debug.Log("��� ��������� ���� ��� ������� ���������.");
            return;
        }

        // ��������� ������� �������� ���� �� ��������� ����
        Attack selectedAttack = validAttacks[Random.Range(0, validAttacks.Count)];

        // ��������� �����
        Attack(selectedAttack.attackType, selectedAttack.damage);

    }
}
