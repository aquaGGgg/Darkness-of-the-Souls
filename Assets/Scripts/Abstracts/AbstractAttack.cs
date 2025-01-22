using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public Animator _animator;

    private int _dmg;

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
    /// гетер дл€ урона, испоьзовать дл€ TakeHit()
    /// </summary>
    /// <returns>возврощает урон </returns>
    public virtual int GetDmg(){
        return dmg;
    }


    /// <summary>
    /// функци€ дл€ переключени€ атак в комбо
    /// </summary>
    public void ComboCompliter()
    {
        _animator.SetInteger("ComboCounter", _animator.GetInteger("ComboCounter") + 1);
    }

    /// <summary>
    /// функци€ принудительного завершени€ комбо
    /// </summary>
    public void EndCombo()
    {
        _animator.SetInteger("ComboCounter", 0);
    }


    /// <summary>
    /// функци€ запускающа€ анимацию полета проджектайла
    /// </summary>
    /// <param name="attackType">номер атаки в AttackType</param>
    /// 
    // переписать дл€ ренживиков.
    public virtual void ProjectileAttackSupport(int attackType)
    {
        _animator.SetInteger("ProjectilelAttackType", attackType);
    }

    /// <summary>
    /// функиц€ дл€ завершени€ атаки, но не комбо
    /// </summary>
    public void ResetAttack()
    {
        _animator.SetInteger("AttackType",0);
    }

    
}
