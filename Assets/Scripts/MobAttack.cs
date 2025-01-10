using UnityEngine;

public class MobAttack : AbstractAttack
{
    void OnTriggerStay(Collider c){
        if(c.gameObject.CompareTag("Finish")){
            Attack(1, dmg);
        }
    }
}
