using System.Collections.Generic;
using UnityEngine;
using PuzzleState = FsmPuzzleState;

public enum FsmPuzzleState
{
    IN_PROGRESS,
    COMPLETE,
    FAIL,
}

public class PuzzleManager : MonoBehaviour
{
    // singleton because manager script 
    public static PuzzleManager Instance { get; private set; }
    public PuzzleState PuzzleState { get; private set; }
    // hashset of completed puzzles 
    private static HashSet<string> completedPuzzles = new();

    // list containing all of our puzzles
    public List<Puzzle> puzzles;

    // total puzzle number
    private int puzzleNumber = 1;
    private int activePuzzleIndex = -1; // -1 indicating no active puzzle

    private void Start()
    {
        // set the puzzle game object to be active 
        Instance = this;

        if (puzzles == null) puzzles = new List<Puzzle>();
        puzzleNumber = puzzles.Count;
    }

    private void Update()
    {

    }

    public void ChangePuzzleState(PuzzleState newState)
    {
        if (PuzzleState == newState) return;

        switch (PuzzleState)
        {
            case PuzzleState.IN_PROGRESS:
                // actual puzzle logic which is handled in 
                // puzzle scripts


                break;
            case PuzzleState.COMPLETE:
                // if all puzzles are complete we win
                GameManager.Instance.ChangeState(FsmGameState.WIN);
                break;
            case PuzzleState.FAIL:
                GameManager.Instance.ChangeState(FsmGameState.LOSE);
                break;
        }
    }

    // check win condition every time a puzzle is completed 
    public void CompletePuzzle(string puzzleName)
    {
        // add the completed puzzle to the hashset 
        completedPuzzles.Add(puzzleName);
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        // if the length of the completed puzzles 
        // is equal to the total number of puzzles 
        if (completedPuzzles.Count >= puzzleNumber)
        {
            GameManager.Instance.ChangeState(FsmGameState.WIN);
        }
    }
}
