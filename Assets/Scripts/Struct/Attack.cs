using System;

namespace Attacks
{
    [Serializable]
    public struct Attack
    {
        public int attackType; // Номер анимации атаки
        public int damage; // Урон от атаки
        public float cooldown; // Время между атаками
        public float range; // Дистанция действия атаки

    }
}
