using UnityEngine;

public class CharacterAttack : AbstractAttack
{

    [SerializeField] private int baseDamage; // ������� ���������
    [SerializeField] private GameObject[] Weapons; // ������� ���������


    private int WeaponInHand = 1;
    // private int[] WeaponDamge - ��� ������ ����� ������ ���� ����� ������ ���� ������ � ������� ����������(���� ���, ����� � ��)

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // ������ �����
            Attack(1, baseDamage);
            Invoke("ResetAttack", 0.3f);
        }
        if(Input.GetKeyDown(KeyCode.J)){ // ������� �����
            Attack(2, baseDamage * 3);
            Invoke("ResetAttack", 1f);
        }
    }

    private void WeaponSwap() // ������� ��� "�����" ������ � �����
    {
        Weapons[WeaponInHand].SetActive(false);
        WeaponInHand = (WeaponInHand + 1) % Weapons.Length;
        Weapons[WeaponInHand -1].SetActive(true);
    }
}
