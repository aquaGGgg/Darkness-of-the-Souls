using UnityEngine;

public class Health : AbstractHealth
{
    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.CompareTag("Weapon") && !c.transform.IsChildOf(transform)){
            CharacterAttack characterAtack = c.gameObject.GetComponent<CharacterAttack>();
            TakeHit(characterAtack.GetDmg());
        }
    }
}
