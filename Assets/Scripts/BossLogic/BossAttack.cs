using UnityEngine;
using UnityEditor.Animations;
using Attacks;

/// <summary>
/// скрипт работает так - метод ExecuteRandomAttack нужно вызывать при паниации появлния босса, 
/// дальше в конце всех анимаций атаки нужно вызывать RandobmCombo через анимационные триггеры
/// </summary>
public class BossAttack : AbstractAttack
{
    [SerializeField] private Transform player;
    [SerializeField] private Attack[] bossAttacks;

    // для расчета времени между атаками
    private float Сooldown; 

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Игрок не назначен! Укажите Transform игрока.");
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

        // если нет доступных атак
        if (validAttacks.Count == 0)
        {
            _animator.SetInteger("AttackType", -1); // либо чардж вперет, либо просто ходьба
        }

        // Случайным образом выбираем одну из доступных атак
        Attack selectedAttack = validAttacks[Random.Range(0, validAttacks.Count)];
        Debug.Log(selectedAttack.attackType);
        // Выполняем атаку
        Attack(selectedAttack.attackType, selectedAttack.damage);
        Сooldown = selectedAttack.cooldown;
    }

    /// <summary>
    /// функция для "броска" на продолжение комбо у босса
    /// </summary>
    /// <param name="ChanceToContinue">процентный шанс на следующую атаку в комбо</param>
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
            Invoke("ExecuteRandomAttack", Сooldown);
        }
    }
}
