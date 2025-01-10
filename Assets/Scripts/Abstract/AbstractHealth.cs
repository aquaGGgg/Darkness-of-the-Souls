using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField]
    protected int hp = 100;

    /// <summary>
    /// получание урона
    /// </summary>
    /// <param name="dmg">получаемый урон, GetDmg() </param>
    public virtual void TakeHit(int dmg) => hp -= dmg;
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="heal">колличество получаемого хп</param>
    public virtual void Heal(int heal) =>  hp+=heal;


    public virtual void Dead() => Destroy(gameObject);
}
