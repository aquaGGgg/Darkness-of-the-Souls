using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUIManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void textSvap()
    {
        if (text.text == "выбрать")
        {
            text.text = "убрать";
        }
        else text.text = "выбрать";
    }

}