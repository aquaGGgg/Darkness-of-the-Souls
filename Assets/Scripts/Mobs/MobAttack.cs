using UnityEngine;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    private int _NumberOfNonEmptyStates; 

    void Start()
    {
        _NumberOfNonEmptyStates = _animator.runtimeAnimatorController.animationClips.Length - 2;// c добовление механик не связаных с атакой моба изменить число
    }

    void OnTriggerStay2D(Collider2D c){
        if(c.gameObject.CompareTag("Player")){
            Attack(Random.Range(1, _NumberOfNonEmptyStates), MobDamage);
        }
    }
}