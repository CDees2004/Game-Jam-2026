using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// example puzzle is an instance of a puzzle 
// solved by clicking UI button 
public class Puzzle_CaptchaText : Puzzle
{
    // set in inspector
    public GameObject puzzelPanel;
    public GameObject testWinButton;
    public Puzzle_SearchBar searchBar;

    // values
    private string solution;

    private void Start()
    {
        puzzleNumber = 1f;
        print("captcha puzzle start called");
        puzzleTimer = 10.0f;

        puzzelPanel.SetActive(true);

        if (testWinButton != null)
        {
            Button testWin = testWinButton.GetComponent<Button>();
            testWin.onClick.AddListener(SolvePuzzle);
        }
    }

    private void Update()
    {
        CheckSolution();
        // timer constantly counting down 
        puzzleTimer -= Time.deltaTime;
        if (puzzleTimer <= 0)
        {
            FailPuzzle();
        }
    }

    public void CheckSolution()
    {
        string userInput = searchBar.GetUserInput();
        if (userInput == solution)
        {
            SolvePuzzle();
        }
    }


    public override void SolvePuzzle()
    {
        print($"Solved {puzzleName}");
        PuzzleManager.Instance.CompletePuzzle(puzzleName);
    }

}
