using System.Collections.Generic;
using UnityEngine;
using PuzzleState = FsmPuzzleState;

public enum FsmPuzzleState
{
    NOT_STARTED,
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
    private int puzzleNumber;
    private int activePuzzleIndex = -1; // -1 indicating no active puzzle

    private void Awake()
    {
        // set the puzzle game object to be active 
        Instance = this;
        PuzzleState = PuzzleState.NOT_STARTED;
    }

    private void Start()
    {
        // making sure all puzzles are inactive at the start of the game
        foreach (Puzzle puzzle in puzzles)
        {
            puzzle.EndPuzzle();
        }

        if (puzzles == null) puzzles = new List<Puzzle>();
        puzzleNumber = puzzles.Count;
    }

    // public entry point 
    public void StartFirstPuzzle()
    {
        print("Start first puzzle called");
        activePuzzleIndex = -1;

        foreach (var puzzle in puzzles)
        {
            puzzle.EndPuzzle(); // turning all off 
        }

        StartNextPuzzle();
    }

    private void StartNextPuzzle()
    {
        activePuzzleIndex++;
        print($"Starting puzzle {activePuzzleIndex}"); 

        if (activePuzzleIndex >= puzzles.Count)
        {
            // there are no more puzzles 
            CheckWinCondition();
            return;
        }
        ChangePuzzleState(PuzzleState.IN_PROGRESS); 
    }

    public void ChangePuzzleState(PuzzleState newState)
    {
        if (PuzzleState == newState) return;
        PuzzleState = newState;

        switch (PuzzleState)
        {
            case PuzzleState.IN_PROGRESS:
                print("puzzle state in progress called");
                Puzzle currentPuzzle = puzzles[activePuzzleIndex];
                currentPuzzle.StartPuzzle();
                break;

            case PuzzleState.COMPLETE:
                // if all puzzles are complete we win
                puzzles[activePuzzleIndex].EndPuzzle(); 
                StartNextPuzzle();
                break;

            case PuzzleState.FAIL:
                puzzles[activePuzzleIndex].EndPuzzle();
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
        ChangePuzzleState(PuzzleState.COMPLETE);
    }

    private void CheckWinCondition()
    {
        print($"puzzleNumber is {puzzleNumber}");
        print($"Completed puzzles count is {completedPuzzles.Count}");
        // if the length of the completed puzzles 
        // is equal to the total number of puzzles 
        if (completedPuzzles.Count >= puzzleNumber)
        {
            GameManager.Instance.ChangeState(FsmGameState.WIN);
        }
    }
}
