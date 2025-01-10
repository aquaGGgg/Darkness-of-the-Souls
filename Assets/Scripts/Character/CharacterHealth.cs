using UnityEngine;

public class CharacterHealth : AbstractHealth
{
    public int healModifier;

    void Update(){
        if(Input.GetKey(KeyCode.H)) Heal(healModifier);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Weapon") && !c.transform.IsChildOf(transform))
        {
            MobAttack mobAttack = c.gameObject.GetComponent<MobAttack>();
            TakeHit(mobAttack.GetDmg());
        }
    }
}