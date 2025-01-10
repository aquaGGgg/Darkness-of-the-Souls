using UnityEngine;

public class MobAttack : AbstractAttack
{
    private int MobDamage;

    void Awake()
    {
        MobDamage = dmg;
        _animator = transform.parent.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D c){
        if(c.gameObject.CompareTag("Player")){
            Attack(1, MobDamage);
        }
    }
}
