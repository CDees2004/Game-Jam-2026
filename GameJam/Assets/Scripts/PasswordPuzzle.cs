using UnityEngine;
using TMPro;

using System.Collections.Generic;


public class PasswordPuzzle : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField passwordInput;
    public TextMeshProUGUI resultText;
    public Transform ruleContainer;
    public RuleBox ruleBoxPrefab;
    private List<RuleBox> spawnRules = new List<RuleBox>();
    private int visibleRuleCount = 0;
    private string[] resultTextList;

    private string[] rules =
    {
        "Your password must be at least 6 characters long.",
        "Your password must contain at least 1 uppercase letter.",
        "Your password must contain at least 1 number.",
        "Your password must contain at least 1 special character (!, @, #, $, %, &, *).",
        // "The sum of all digits in your password must equal 25.",
        // "Your password must contain the name of a color.",
        // "Your password must contain a month of the year.",
        // "Your password must contain a Roman numeral (I, V, X, L, C).",
        // "Your password must not contain the same character twice in a row.",
        // "Your password must end with a symbol chosen by the game."
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultTextList = new string[]
                {
                    "Are you a robot ???",
                    "Are you a human ??",
                    "Robot is almost detected !!",
                    "Let a human help you !!"
                };
        AddNextRule();
    }

    public void CheckPassword()
    { 
        string password = passwordInput.text;
        for (int i=0; i <= visibleRuleCount; i++)
        {
            bool passed = CheckRule(i,password);
            spawnRules[i].SetPassed(passed);

            // get wrong input
            if (!passed)
            {   
                resultText.text = resultTextList[Random.Range(0,resultTextList.Length)];
                return;
            }

            // right input, but still have more rule
            if(visibleRuleCount < rules.Length)
            {
                resultText.text = resultTextList[Random.Range(0,resultTextList.Length)];
                AddNextRule();
            }
            else
            {
                resultText.text = "The password is accepted";
            }
        }
    }

    public void AddNextRule()
    {
        if (visibleRuleCount > rules.Length) return;

        RuleBox newRule = Instantiate(ruleBoxPrefab,ruleContainer);
        newRule.SetUp(rules[visibleRuleCount]);
        newRule.transform.SetAsFirstSibling();

        spawnRules.Add(newRule);
        visibleRuleCount++;
    }

    public bool CheckRule(int index, string password)
    {
        switch (index)
        {
            case 0: return password.Length > 6;
            case 1: return HasUpperCase(password);
            case 2: return HasNumber(password);
            case 3: return HasSpecialCharacter(password);
            default: return false;
        }
    }
    bool HasUpperCase(string s)
    {
        foreach (char c in s)
        {
            if (char.IsUpper(c)) return true;
        }return false;
    }

    public bool HasNumber(string s)
    {
        foreach (char c in s)
        {
            if (char.IsNumber(c)) return true;
        }return false;
    }

    public bool HasSpecialCharacter(string s)
    {
        string special = "!@#$%&*";
        foreach (char c in s)
        {
            if (special.Contains(char.ToString(c))) return true;
        }return false;
    }
}

