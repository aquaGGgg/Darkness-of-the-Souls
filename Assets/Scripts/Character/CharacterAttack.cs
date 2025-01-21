using UnityEngine;
using Attacks;


public class CharacterAttack : AbstractAttack
{
    [SerializeField] private CharakterSkils[] AllAttacks; //  ��� ������������� �����
    
    [SerializeField] private int baseDamage; // ������� ���������
    [SerializeField] private GameObject[] Weapons; // ����� ������

    void Start()
    {
        Controller.UnlockScill += UnlockScill;
    }


    private int WeaponInHand = 1;
    // private int[] WeaponDamge - ��� ������ ����� ������ ���� ����� ������ ���� ������ � ������� ����������(���� ���, ����� � ��)

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ //����� ������������ ������ 
            Attack(1, baseDamage);
            Invoke("ResetAttack", 0.3f);
        }


        if(Input.GetKeyDown(KeyCode.J)){ // ������� �����
            Attack(2, baseDamage * 3);
            Invoke("ResetAttack", 1f);
        }
        if (Input.GetKeyDown(KeyCode.I))// ������ �����
        { 
            Attack(1, baseDamage);
            Invoke("ResetAttack", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.O))// ������� �����
        { 
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


    public void UnlockScill(int BS) // ������� �������� ������
    {
        AllAttacks[BS].isUnlok = true;
    }
}
