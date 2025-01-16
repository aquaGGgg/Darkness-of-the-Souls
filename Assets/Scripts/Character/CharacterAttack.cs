using UnityEngine;

public class CharacterAttack : AbstractAttack
{
    // скрипт вешать на оружие чарактера

    public int WeaponDamage; // бызавый урон оружия урон 
     


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // слабая атака
            Attack(1, WeaponDamage);
            Invoke("ResetAttack", 0.3f);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // сильная атака
            Attack(2, WeaponDamage * 3);
            Invoke("ResetAttack", 1f);
        }
    }
}
