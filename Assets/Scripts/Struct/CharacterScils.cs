using System;

namespace Attacks
{
    [Serializable]
    public struct CharakterSkils
    {
        public int attackType; // ����� �������� �����
        public int damage; // ���� �� �����
        public float cooldown; // ����� ����� �������
        public bool isUnlok; // ������ �� ����
    }
}
