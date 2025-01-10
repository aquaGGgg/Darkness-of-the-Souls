using UnityEngine;

public class CharacterAttack : AbstractAttack
{
    // скрипт вешать на оружие чарактера

    public int WeaponDamage; // бызавый урон оружия урон 
     
    void Awake()
    {
        _animator = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // слабая атака
            Attack(1, WeaponDamage);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // сильная атака
            Attack(2, WeaponDamage * 3); 
        }
    }
}
