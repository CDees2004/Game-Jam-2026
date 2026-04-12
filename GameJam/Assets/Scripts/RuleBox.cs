using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RuleBox : MonoBehaviour
{
    public TextMeshProUGUI ruleText;
    public Image background;

    public Color passedColor = new Color(0.529f,0.98f,0.447f); // green
    public Color lockColor = new Color(1f,0.514f,0.514f); //red

    public void SetUp (string text)
    {
        ruleText.text = text;
        SetPassed(false);
    }
    public void SetPassed(bool passed)
    {
        //if it true:passed green, flase red
        background.color = passed ? passedColor : lockColor;
    }
}
