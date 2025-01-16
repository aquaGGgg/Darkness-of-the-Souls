using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField]
    protected int MaxHp;

    [SerializeField]
    protected int hp;


    private Animator _animator;

    void Start()
    {
        hp = MaxHp;
        _animator = GetComponent<Animator>();
    }
    /// <summary>
    /// получание урона
    /// </summary>
    /// <param name="dmg">получаемый урон, GetDmg() </param>
    public virtual void TakeHit(int dmg) {
        if (hp > 0) hp -= dmg;
        else {
        _animator.SetBool("IsDead", true);
        }
    }
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="heal">колличество получаемого хп</param>
    public virtual void Heal(int heal){
        if(hp + heal <= MaxHp)
        {
            hp+= heal;
        }
        else hp = MaxHp;
    }



    private void Dead() => Destroy(gameObject);
}
