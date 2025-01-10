using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField]
    protected int hp = 100;

    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="dmg">���������� ����, GetDmg() </param>
    public virtual void TakeHit(int dmg) => hp -= dmg;
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="heal">����������� ����������� ��</param>
    public virtual void Heal(int heal) =>  hp+=heal;


    public virtual void Dead() => Destroy(gameObject);
}
