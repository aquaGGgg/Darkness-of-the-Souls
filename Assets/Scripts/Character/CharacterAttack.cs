using UnityEngine;
using System.Collections.Generic;
using Attacks;


public class CharacterAttack : AbstractAttack
{
    [SerializeField] private CharakterSkils[] AllAttacks; //  ��� ������������� �����
    
    [SerializeField] private int baseDamage; // ������� ���������
    [SerializeField] private List<int> UsesSkillsIndex; // ����� ������
    [SerializeField] private GameObject[] Weapons; // ����� ������


    void Start()
    {
        Controller.UnlockScill += UnlockScill; 
        UsesSkillsIndex = new List<int> { -1, -1, -1 };
    }


    private int WeaponInHand = 1;
    // private int[] WeaponDamge - ��� ������ ����� ������ ���� ����� ������ ���� ������ � ������� ����������(���� ���, ����� � ��)

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ //����� ������������ ������ 
            Attack(1, baseDamage);
            Invoke("ResetAttack", 0.3f);
        }


        if(Input.GetKeyDown(KeyCode.J)){ // ����� 1 
            Attack(AllAttacks[UsesSkillsIndex[0]].attackType, AllAttacks[UsesSkillsIndex[0]].damage);
            Invoke("ResetAttack", AllAttacks[UsesSkillsIndex[0]].cooldown);
            Debug.Log(AllAttacks[UsesSkillsIndex[0]].attackType);
        }
        if (Input.GetKeyDown(KeyCode.I))// ����� 2 
        { 
            Attack(AllAttacks[UsesSkillsIndex[1]].attackType, AllAttacks[UsesSkillsIndex[1]].damage);
            Invoke("ResetAttack", AllAttacks[UsesSkillsIndex[1]].cooldown);
        }
        if (Input.GetKeyDown(KeyCode.O))// ����� 3
        { 
            Attack(AllAttacks[UsesSkillsIndex[2]].attackType, AllAttacks[UsesSkillsIndex[2]].damage);
            Invoke("ResetAttack", AllAttacks[UsesSkillsIndex[2]].cooldown);
        }
    }

    public void UnlockScill(int BS) // ������� �������� ������
    {
        AllAttacks[BS].isUnlok = true;  
    }

    public void UseSkill(int SkillIndex)
    {
        for (int i = 0; i<=2; i++)
        {
            Debug.Log(i);
            if (UsesSkillsIndex[i] == -1)
            {
                UsesSkillsIndex[i] = SkillIndex;
                return;
            }
            else if (UsesSkillsIndex[i] == SkillIndex)
            {

                UsesSkillsIndex[SkillIndex] = -1;
            }
        }
    }

    private void WeaponSwap() // ������� ��� "�����" ������ � �����
    {
        Weapons[WeaponInHand].SetActive(false);
        WeaponInHand = (WeaponInHand + 1) % Weapons.Length;
        Weapons[WeaponInHand -1].SetActive(true);
    }
}
