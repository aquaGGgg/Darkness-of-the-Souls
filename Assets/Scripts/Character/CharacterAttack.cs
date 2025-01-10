using UnityEngine;

public class CharacterAttack : AbstractAttack
{
    // скрипт вешать на оружие чарактера

    private int CharacterDmg; // локальный урон 
     
    void Awake()
    {
        CharacterDmg = dmg;
        _animator = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // слабая атака
            Attack(1, CharacterDmg);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // сильная атака
            Attack(2, CharacterDmg * 3); 
        }
    }
}
