using UnityEngine;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    private int _NumberOfNonEmptyStates;
    private Vector2 wallPosicion;

    void Start()
    {
        wallPosicion = new Vector2(99999,99999);
        _NumberOfNonEmptyStates = _animator.runtimeAnimatorController.animationClips.Length - 3;// c добовление механик не связаных с атакой моба изменить число
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Wall"))
        {
            wallPosicion = c.gameObject.transform.position;
        }
           
        if (Vector2.Distance(transform.position, wallPosicion) > Vector2.Distance(transform.position, c.gameObject.transform.position) && c.gameObject.CompareTag("Player"))
        {
            Attack(Random.Range(1, _NumberOfNonEmptyStates), MobDamage);
        }
    }

}