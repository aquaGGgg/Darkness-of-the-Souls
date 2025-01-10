using UnityEngine;

public class CharacterHealth : AbstractHealth
{

    private int MaxHp = 150;
    public int healModifier;

    void Update(){
        if(Input.GetKey(KeyCode.H) && hp + healModifier <= MaxHp){
            Heal(healModifier);
        }   
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Weapon") && !c.transform.IsChildOf(transform))
        {
            if (hp > 0){
                MobAttack mobAttack = c.gameObject.GetComponent<MobAttack>();
                TakeHit(mobAttack.GetDmg());
            }
            else Dead();
        }
    }
}