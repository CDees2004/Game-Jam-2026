using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// example puzzle is an instance of a puzzle 
// solved by clicking UI button 
public class Puzzle_TestPuzzle : Puzzle
{
    // set in inspector
    public GameObject puzzelPanel;
    public GameObject testWinButton;

    private void Start()
    {
        print("test puzzle start called");
        puzzleName = "Test Puzzle";
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
        // timer constantly counting down 
        puzzleTimer -= Time.deltaTime;
        if (puzzleTimer <= 0)
        {
            FailPuzzle();
        }
    }


    public override void SolvePuzzle()
    {
        print("Solved test puzzle");
        PuzzleManager.Instance.CompletePuzzle(puzzleName);
    }

}
