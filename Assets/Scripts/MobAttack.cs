using UnityEngine;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D c){
        if(c.gameObject.CompareTag("Player")){
            Attack(1, MobDamage);
        }
    }
}
