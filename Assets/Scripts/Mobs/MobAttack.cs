using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    private int _NumberOfNonEmptyStates;
    private Vector2 wallPosicion; // ���������� ������ ������� ����� �����, ���� �� ���� ����� �����

    void Start()
    {
        wallPosicion = new Vector2(99999,99999); // ����� �������� null poiter exaption, ����� �������� ��� ���������� ������� �����


        // �������� ����������� ��������� �� ������� ���� � �������� ����������� �������� �� �������� � �������
        _NumberOfNonEmptyStates = (_animator.runtimeAnimatorController as AnimatorController).layers[0].stateMachine.states.Length - 3;

    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Wall")) // ��������� ������� �����
        {
            wallPosicion = c.gameObject.transform.position;
        }
           
        if (Vector2.Distance(transform.position, wallPosicion) > Vector2.Distance(transform.position, c.gameObject.transform.position) && c.gameObject.CompareTag("Player"))
        {
            Attack(Random.Range(1, _NumberOfNonEmptyStates), MobDamage);
        }
    }

}