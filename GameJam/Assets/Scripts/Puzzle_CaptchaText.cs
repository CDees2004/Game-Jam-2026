using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

// example puzzle is an instance of a puzzle 
// solved by clicking UI button 
public class Puzzle_CaptchaText : Puzzle
{
    // set in inspector
    public GameObject puzzelPanel;
    public GameObject testWinButton;
    public TMP_InputField input;

    // fields
    private string solution;
    private float puzzlenumber;

    private void Start()
    {
        puzzlenumber = 1f;
        print("captcha puzzle start called");
        puzzleTimer = 10.0f;
        puzzleName = "captcha-i_am_stupid";
        solution = "i am stupid";

        puzzelPanel.SetActive(true);

        if (testWinButton != null)
        {
            Button testWin = testWinButton.GetComponent<Button>();
            testWin.onClick.AddListener(CheckSolution);
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

    private void CheckSolution()
    {
        if (input.text == solution)
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
