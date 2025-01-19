using UnityEngine;
using UnityEditor.Animations;
using Attacks;

/// <summary>
/// ������ �������� ��� - ����� ExecuteRandomAttack ����� �������� ��� �������� �������� �����, 
/// ������ � ����� ���� �������� ����� ����� �������� RandobmCombo ����� ������������ ��������
/// </summary>
public class BossAttack : AbstractAttack
{
    [SerializeField] private Transform player;
    [SerializeField] private Attack[] bossAttacks;

    // ��� ������� ������� ����� �������
    private float �ooldown; 

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("����� �� ��������! ������� Transform ������.");
        }
            Invoke("ExecuteRandomAttack", 2);
    }

    void Update()
    {
        float directionX = player.position.x - transform.position.x;
        if (Mathf.Abs(directionX) > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Sign(directionX) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }



    private void ExecuteRandomAttack()
    {
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

        // ���� ��� ��������� ����
        if (validAttacks.Count == 0)
        {
            _animator.SetInteger("AttackType", -1); // ���� ����� ������, ���� ������ ������
        }

        // ��������� ������� �������� ���� �� ��������� ����
        Attack selectedAttack = validAttacks[Random.Range(0, validAttacks.Count)];
        Debug.Log(selectedAttack.attackType);
        // ��������� �����
        Attack(selectedAttack.attackType, selectedAttack.damage);
        �ooldown = selectedAttack.cooldown;
    }

    /// <summary>
    /// ������� ��� "������" �� ����������� ����� � �����
    /// </summary>
    /// <param name="ChanceToContinue">���������� ���� �� ��������� ����� � �����</param>
    void RandobmCombo(int ChanceToContinue)
    {
        Debug.Log("asd");
        if (Random.Range(0, 100) >= 100 - ChanceToContinue)
        {
            ComboCompliter();
        }
        else
        {
            EndCombo(); 
            ResetAttack();
            Invoke("ExecuteRandomAttack", �ooldown);
        }
    }
}
