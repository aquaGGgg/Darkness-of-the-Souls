using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public Animator _animator;

    private int _dmg;

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


    /// <summary>
    /// ������� ��� ������������ ���� � �����
    /// </summary>
    public void ComboCompliter()
    {
        _animator.SetInteger("ComboCounter", _animator.GetInteger("ComboCounter") + 1);
    }

    /// <summary>
    /// ������� ��������������� ���������� �����
    /// </summary>
    public void EndCombo()
    {
        _animator.SetInteger("ComboCounter", 0);
    }


    /// <summary>
    /// ������� ����������� �������� ������ ������������
    /// </summary>
    /// <param name="attackType">����� ����� � AttackType</param>
    /// 
    // ���������� ��� ����������.
    public virtual void ProjectileAttackSupport(int attackType)
    {
        _animator.SetInteger("ProjectilelAttackType", attackType);
    }

    /// <summary>
    /// ������� ��� ���������� �����, �� �� �����
    /// </summary>
    public void ResetAttack()
    {
        _animator.SetInteger("AttackType",0);
    }

    
}
