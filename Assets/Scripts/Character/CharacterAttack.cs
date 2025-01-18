using UnityEngine;

public class CharacterAttack : AbstractAttack
{

    [SerializeField] private int baseDamage; // бызавый чарактера
    [SerializeField] private GameObject[] Weapons; // бызавый чарактера


    private int WeaponInHand = 1;
    // private int[] WeaponDamge - как пример урона оружия если будут разные типы оружия с разными анимациями(типо меч, копьё и тп)

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // слабая атака
            Attack(1, baseDamage);
            Invoke("ResetAttack", 0.3f);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // сильная атака
            Attack(2, baseDamage * 3);
            Invoke("ResetAttack", 1f);
        }
    }

    private void WeaponSwap() // функция для "смены" оружия в руках
    {
        Weapons[WeaponInHand].SetActive(false);
        WeaponInHand = (WeaponInHand + 1) % Weapons.Length;
        Weapons[WeaponInHand -1].SetActive(true);
    }
}
