using UnityEngine;

public class CharacterAttack : AbstractAttack
{
    // ������ ������ �� ������ ���������

    public int WeaponDamage; // ������� ���� ������ ���� 
     


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // ������ �����
            Attack(1, WeaponDamage);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // ������� �����
            Attack(2, WeaponDamage * 3); 
        }
    }
}
