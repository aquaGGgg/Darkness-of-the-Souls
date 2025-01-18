using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class MobAttack : AbstractAttack
{
    public int MobDamage;

    private int _NumberOfNonEmptyStates;
    private Vector2 wallPosicion; // переменная хранит позицию стены стену, чтоб не бить через стену

    void Start()
    {
        wallPosicion = new Vector2(99999,99999); // чтобы избежать null poiter exaption, такое значение для корректной рабботы атаки


        // Получаем колличество анимааций на нулевом слое и вычитаем колличаство анимаций не связаных с аттакой
        _NumberOfNonEmptyStates = (_animator.runtimeAnimatorController as AnimatorController).layers[0].stateMachine.states.Length - 3;

    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Wall")) // обнавляет позицию стены
        {
            wallPosicion = c.gameObject.transform.position;
        }
           
        if (Vector2.Distance(transform.position, wallPosicion) > Vector2.Distance(transform.position, c.gameObject.transform.position) && c.gameObject.CompareTag("Player"))
        {
            Attack(Random.Range(1, _NumberOfNonEmptyStates), MobDamage);
        }
    }

}