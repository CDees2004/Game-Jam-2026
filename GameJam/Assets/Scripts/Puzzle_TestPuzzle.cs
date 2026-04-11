using UnityEngine;
using UnityEngine.UI;

// example puzzle is an instance of a puzzle 
// solved by clicking UI button 
public class Puzzle_TestPuzzle : Puzzle
{
    // set in inspector
    public GameObject testWinButton;

    // puzzle params 
    private string puzzleName = "Test Puzzle"; 
    private float puzzleTimer = 60.0f;

    public Puzzle_TestPuzzle(string puzzleName, float puzzleTimer, bool isComplete) : base(puzzleName, puzzleTimer)
    {

    }

    public override void SolvePuzzle()
    {
        print("Solved test puzzle");
        PuzzleManager.Instance.CompletePuzzle(puzzleName); 
    }
   

    private void Start()
    {
        if(testWinButton != null)
        {
            Button testWin = testWinButton.GetComponent<Button>();
            testWin.onClick.AddListener(SolvePuzzle);
        }
    }

    private void Update()
    {
        
    }
}
