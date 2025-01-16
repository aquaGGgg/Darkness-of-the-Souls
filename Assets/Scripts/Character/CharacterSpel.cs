using UnityEngine;

public class CharacterSpel : AbstractAttack
{
    // мб слить с чарактер атакой, тк  логика отличается только в спавне проджектайла

    public GameObject[] spels;
    public int StalDamage;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        { // сильная атака
            Attack(3, StalDamage * 3);
        }
    }
}
