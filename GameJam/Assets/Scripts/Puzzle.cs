using UnityEngine;


// template script for individual puzzles to be 
// overriden with actual implementation details 
// by the puzzles 
public class Puzzle : MonoBehaviour
{
    // every puzzle should have a name, timer, and win condition
    private string puzzleName;
    private float puzzleTimer;
    private bool isComplete;

    public Puzzle(string puzzleName, float puzzleTimer, bool isComplete)
    {
        this.puzzleName = puzzleName;
        this.puzzleTimer = puzzleTimer;
        this.isComplete = isComplete;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
