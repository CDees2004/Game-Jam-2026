using UnityEngine;
using UnityEngine.Rendering;


// template script for individual puzzles to be 
// overriden with actual implementation details 
// by the puzzles 
public class Puzzle : MonoBehaviour
{
    // every puzzle should have a name, timer, and win condition
    protected string puzzleName;
    protected float puzzleTimer;

    public virtual void StartPuzzle()
    {
        gameObject.SetActive(true);
    }

    public virtual void EndPuzzle()
    {
        gameObject.SetActive(false);
    }

    protected void FailPuzzle()
    {
        PuzzleManager.Instance.ChangePuzzleState(FsmPuzzleState.FAIL);
    }

    public virtual void SolvePuzzle()
    {
        // override this in actual puzzle scripts 
        print("Calling virtual implementation of SolvePuzzle");
        PuzzleManager.Instance.CompletePuzzle(puzzleName);
    }
}
