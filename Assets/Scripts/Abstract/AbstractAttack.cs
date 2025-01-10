using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    protected Animator _animator;

    [SerializeField]
    protected int dmg;

    /// <summary>
    /// метод вызывающий атаку
    /// </summary>
    /// <param name="attackType">номер анимации атаки</param>
    /// <param name="attakDamage">урон от атаки</param>
    public virtual void Attack(int attackType, int attakDamage)
    {
        dmg = attakDamage;
        _animator.SetInteger("AttackType",attackType);
        Invoke("ResetAttack", _animator.GetCurrentAnimatorStateInfo(0).length +0.1f); 
    }

    /// <summary>
    /// гетер для урона
    /// </summary>
    /// <returns></returns>
    public virtual int GetDmg(){
        return dmg;
    }


    private void ResetAttack(){
        _animator.SetInteger("AttackType",0);
    }

    
}
