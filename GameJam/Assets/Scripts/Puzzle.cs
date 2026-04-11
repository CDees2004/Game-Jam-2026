using UnityEngine;


// template script for individual puzzles to be 
// overriden with actual implementation details 
// by the puzzles 
public class Puzzle : MonoBehaviour
{
    // every puzzle should have a name, timer, and win condition
    private string puzzleName;
    private float puzzleTimer;

    public Puzzle(string puzzleName, float puzzleTimer)
    {
        this.puzzleName = puzzleName;
        this.puzzleTimer = puzzleTimer;
    }

    public virtual void SolvePuzzle()
    {
        // override this in actual puzzle scripts 
        print("Calling virtual implementation of SolvePuzzle"); 
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
