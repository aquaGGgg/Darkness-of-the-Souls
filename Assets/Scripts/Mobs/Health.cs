using UnityEngine;

public class Health : AbstractHealth
{
    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.CompareTag("Weapon") && c.gameObject.TryGetComponent<CharacterAttack>(out CharacterAttack a))
        {
            CharacterAttack characterAtack = c.gameObject.GetComponent<CharacterAttack>();
            if (characterAtack._animator.GetInteger("AttackType") != 0 && characterAtack != null)
            {
            TakeHit(characterAtack.GetDmg());
            }
        }
    }
}