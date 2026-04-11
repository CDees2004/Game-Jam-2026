using System.Collections.Generic;
using UnityEngine;
using GameState = FsmGameState;

public enum FsmGameState
{
    START_SCREEN,
    IN_PUZZLE,
    WIN,
    LOSE,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState GameState { get; private set; }

    private void Start()
    {
        GameState = GameState.START_SCREEN;
    }


    private void Update()
    {

    }


    // the one to be messed with by other scripts 
    public void ChangeState(GameState newState)
    {
        switch (GameState)
        {
            case GameState.START_SCREEN:
                // restartaing is handled with scene reload 
                // so this state should not need behavior
                break;

            case GameState.IN_PUZZLE:
                // go to the puzzle manager
                PuzzleManager.Instance.ChangePuzzleState(FsmPuzzleState.IN_PROGRESS);
                break;

            case GameState.WIN:

                break;

            case GameState.LOSE:
                break;
        }
    }
}
