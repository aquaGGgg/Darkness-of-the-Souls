using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public Animator _animator;

    private int dmg;

    /// <summary>
    /// ����� ���������� �����
    /// </summary>
    /// <param name="attackType">����� �������� �����</param>
    /// <param name="attakDamage">���� �� �����</param>
    public virtual void Attack(int attackType, int attakDamage)
    {
        dmg = attakDamage;
        _animator.SetInteger("AttackType",attackType);
    }

    /// <summary>
    /// ����� ��� �����, ����������� ��� TakeHit()
    /// </summary>
    /// <returns>���������� ���� </returns>
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
