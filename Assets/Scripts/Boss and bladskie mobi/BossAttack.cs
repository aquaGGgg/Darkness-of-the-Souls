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
            Debug.LogError("Игрок не назначен! Укажите Transform игрока.");
        }
    }

    public void ExecuteRandomAttack()
    {
        if (player == null) return;

        // Рассчитываем дистанцию до игрока
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Выбираем доступные атаки, которые могут достать игрока
        var validAttacks = new System.Collections.Generic.List<Attack>();
        foreach (var attack in bossAttacks)
        {
            if (distanceToPlayer <= attack.range)
            {
                validAttacks.Add(attack);
            }
        }

        // Если доступных атак нет, ничего не делаем
        if (validAttacks.Count == 0)
        {
            Debug.Log("Нет доступных атак для текущей дистанции.");
            return;
        }

        // Случайным образом выбираем одну из доступных атак
        Attack selectedAttack = validAttacks[Random.Range(0, validAttacks.Count)];

        // Выполняем атаку
        Attack(selectedAttack.attackType, selectedAttack.damage);

    }
}
