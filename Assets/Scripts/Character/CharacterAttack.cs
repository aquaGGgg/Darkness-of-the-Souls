using UnityEngine;

public class CharacterAttack : AbstractAttack
{
    // ������ ������ �� ������ ���������

    private int CharacterDmg; // ��������� ���� 
     
    void Awake()
    {
        CharacterDmg = dmg;
        _animator = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // ������ �����
            Attack(1, CharacterDmg);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // ������� �����
            Attack(2, CharacterDmg * 3); 
        }
    }
}
