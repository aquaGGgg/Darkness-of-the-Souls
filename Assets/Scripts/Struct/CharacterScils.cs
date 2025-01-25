using System;

namespace Attacks
{
    [Serializable]
    public struct CharakterSkils
    {
        public int attackType; // Номер анимации атаки
        public int damage; // Урон от атаки
        public float cooldown; // Время между атаками
        public bool isUnlok; // открыт ли скил
    }
}
