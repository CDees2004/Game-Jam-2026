using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_BrainUpgrade : Puzzle
{
    public GameObject brainWinButton;
    public TMP_InputField textField;

    private void Start()
    {
        puzzleName = "Brain Upgrade 2";
        puzzleTimer = 100.0f; 

        if (brainWinButton != null)
        {
            Button brainWin = brainWinButton.GetComponent<Button>();
            brainWin.onClick.AddListener(SolvePuzzle); 
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

    public string GetUserInput()
    {
        return textField.text; 
    } 
}
