using UnityEngine;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    void OnTriggerStay2D(Collider2D c){
        if(c.gameObject.CompareTag("Player")){
            Attack(1, MobDamage);
        }
    }
}
