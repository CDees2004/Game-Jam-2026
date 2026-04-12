using UnityEngine;
using TMPro;

using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;


public class PasswordPuzzle : Puzzle
{
    [Header("UI")]
    public GameObject DoneButton;
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
        "Your password must contain at least 4 uppercase letter.",
        "Your password must contain at least 5 number.",
        "Your password must contain at least 2 special character (!, @, #, $, %, &, *).",
        "The sum of all digits in your password must equal 25.",
        //"Your password cannot contain two identical characters in a row",

    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        //set puzzle name and time
        puzzleName = "Password Puzzle";
        puzzleTimer = 15.0f; 

        resultTextList = new string[]
                {
                    "Are you a robot ???",
                    "Are you a human ??",
                    "Robot is almost detected !!",
                    "Let a human help you !!",
                    "Robot ?? ",
                };
        AddNextRule();
        passwordInput.onValueChanged.AddListener(delegate{CheckPassword();});

        // check for Done button, if click, change to SolvePuzzle
        if (DoneButton != null)
        {
            Button WinPuzzle = DoneButton.GetComponent<Button>();
            WinPuzzle.onClick.AddListener(SolvePuzzle);
        }

    }

    private void Update()
    {
        // timer constantly counting down 
        puzzleTimer -= Time.deltaTime;
        if (puzzleTimer <= 0)
        {
            FailPuzzle();
        }
    }

    public override void SolvePuzzle()
    {
        print("Solved Password Puzzle");
        PuzzleManager.Instance.CompletePuzzle(puzzleName);
    }

    public void CheckPassword()
    { 
        string password = passwordInput.text;
        
        bool allPassed = true;

        for (int i=0; i < visibleRuleCount; i++)
        {
            bool passed = CheckRule(i,password); // check the current password
            spawnRules[i].SetPassed(passed); // change the color of current rule

            if (!passed)
            {
                allPassed = false;
            }
        }

        // get wrong input
        if (!allPassed)
        {   
            resultText.text = resultTextList[Random.Range(0,resultTextList.Length)];
            SoundManager.Play(SoundType.WRONG);
            return;
            
        }

        // right input, but still have more rule
        if(visibleRuleCount < rules.Length)
        {
            resultText.text = resultTextList[Random.Range(0,resultTextList.Length)];
            AddNextRule();
            int newRuleIndex = visibleRuleCount - 1;
            bool newRulePassed = CheckRule(newRuleIndex,password);
            spawnRules[newRuleIndex].SetPassed(newRulePassed); // set the color

            if (newRulePassed)
            {
                CheckPassword();
            }
        }
        else
        {
            resultText.text = "The password is accepted";
            SoundManager.Play(SoundType.CORRECT);
        }
    }

    public void AddNextRule()
    {
        if (visibleRuleCount >= rules.Length) return;

        RuleBox newRule = Instantiate(ruleBoxPrefab,ruleContainer);
        newRule.SetUp(rules[visibleRuleCount]);
        newRule.transform.SetAsFirstSibling();

        spawnRules.Add(newRule);
        visibleRuleCount++;
    }

    public void AddCurrentRule()
    {
        RuleBox currentRule = Instantiate(ruleBoxPrefab,ruleContainer);
        currentRule.SetUp(rules[visibleRuleCount-1]);
        currentRule.transform.SetAsFirstSibling();
        spawnRules.Add(currentRule);
    }

    public bool CheckRule(int index, string password)
    {
        switch (index)
        {
            case 0: return password.Length >= 6;
            case 1: return HasUpperCase(password);
            case 2: return HasNumber(password);
            case 3: return HasSpecialCharacter(password);
            case 4: return HasSumEqual_25(password);
            //case 5: return HasTwoIdentical(password);
            default: return false;
        }
    }
    bool HasUpperCase(string s)
    {
        int countUpper = 0;
        foreach (char c in s)
        {
            if (char.IsUpper(c))
            {
                countUpper++;
            } 
            if (countUpper >= 4) return true;
        }return false;
    }

    public bool HasNumber(string s)
    {
        int countNum = 0;
        foreach (char c in s)
        {
            if (char.IsNumber(c)) {
                countNum++;
            }
        }
        if (countNum >= 5) return true;
        return false;
    }

    public bool HasSpecialCharacter(string s)
    {
        int countSpecial = 0;
        string special = "!@#$%&*";
        foreach (char c in s)
        {
            if (special.Contains(char.ToString(c)))
            {
                countSpecial++;
            }
            if (countSpecial >= 2) return true;
        }return false;
    }

    public bool HasSumEqual_25(string s)
    {
        int countSum = 0;
        foreach (char c in s)
        {
            if (char.IsNumber(c)) {
                int currentNum = c - '0';
                countSum += currentNum;
            }
        }
        if (countSum == 25) return true;
        return false;
    }

    // public bool HasTwoIdentical(string s)
    // {
    //     for (int i=0; i < s.Length-1; i++)
    //     {
    //         if (s[i] == s[i+1]) return true;
    //     }return false;
    // }
}

