using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public Animator _animator;

    private int dmg;

    /// <summary>
    /// метод вызывающий атаку
    /// </summary>
    /// <param name="attackType">номер анимации атаки</param>
    /// <param name="attakDamage">урон от атаки</param>
    public virtual void Attack(int attackType, int attakDamage)
    {
        dmg = attakDamage;
        _animator.SetInteger("AttackType",attackType);
    }

    /// <summary>
    /// гетер для урона, испоьзовать для TakeHit()
    /// </summary>
    /// <returns>возврощает урон </returns>
    public virtual int GetDmg(){
        return dmg;
    }


    public virtual void ProjectileAttackSupport(int attackType)
    {
        _animator.SetInteger("ProjectilelAttackType", attackType);
    }

    public void ResetAttack()
    {
        _animator.SetInteger("AttackType",0);
    }

    
}
