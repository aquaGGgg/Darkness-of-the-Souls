using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField]
    protected int MaxHp;

    [SerializeField]
    protected int hp;

    void Start() => hp = MaxHp;
    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="dmg">���������� ����, GetDmg() </param>
    public virtual void TakeHit(int dmg) {
        if (hp > 0) hp -= dmg;
        else Dead();
    }
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="heal">����������� ����������� ��</param>
    public virtual void Heal(int heal){
        if(hp + heal <= MaxHp)
        {
            hp+= heal;
        }
        else hp = MaxHp;
    }



    private void Dead() => Destroy(gameObject);
}
