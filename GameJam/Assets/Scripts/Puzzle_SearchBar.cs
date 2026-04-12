using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// example puzzle is an instance of a puzzle 
// solved by clicking UI button 
public class Puzzle_SearchBar : Puzzle
{
    // set in inspector
    public GameObject puzzelPanel;
    public GameObject testWinButton;
    public TMP_InputField textField;

    private void Start()
    {
        puzzleName = "Test Puzzle";
        puzzleTimer = 100.0f; 

        puzzelPanel.SetActive(true);

        if (testWinButton != null)
        {
            Button testWin = testWinButton.GetComponent<Button>();
            testWin.onClick.AddListener(SolvePuzzle);
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


    public override void SolvePuzzle()
    {
        print("Solved test puzzle");
        PuzzleManager.Instance.CompletePuzzle(puzzleName);
    }

}
