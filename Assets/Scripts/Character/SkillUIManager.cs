using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUIManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void textSvap()
    {
        if (text.text == "�������")
        {
            text.text = "������";
        }
        else text.text = "�������";
    }

}