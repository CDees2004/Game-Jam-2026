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

    // total puzzle number
    private int puzzleNumber = 1;

    private void Start()
    {

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
                PuzzleState = PuzzleState.COMPLETE;
                break;
            case PuzzleState.COMPLETE:
                PuzzleState = PuzzleState.FAIL;
                break;
            case PuzzleState.FAIL:
                PuzzleState = PuzzleState.IN_PROGRESS;
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
