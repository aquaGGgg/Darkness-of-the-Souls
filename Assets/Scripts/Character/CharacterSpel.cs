using UnityEngine;

public class CharacterSpel : AbstractAttack
{
    // �� ����� � �������� ������, ��  ������ ���������� ������ � ������ ������������

    public GameObject[] spels;
    public int StalDamage;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        { // ������� �����
            Attack(3, StalDamage * 3);
        }
    }
}
