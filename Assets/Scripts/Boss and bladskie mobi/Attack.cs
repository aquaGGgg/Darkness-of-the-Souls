using System;

namespace Attacks
{
    [Serializable]
    public struct Attack
    {
        public int attackType; // ����� �������� �����
        public int damage; // ���� �� �����
        public float cooldown; // ����� ����� �������
        public float range; // ��������� �������� �����

    }
}
