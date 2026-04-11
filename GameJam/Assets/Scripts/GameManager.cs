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
    public GameState GameState { get; private set; }
    private HashSet<KeyValuePair<GameState, GameState>> allowedTransitions;


    private void Start()
    {
        GameState = GameState.START_SCREEN;
        allowedTransitions = new()
        {
            new(GameState.START_SCREEN, GameState.IN_PUZZLE),
            new(GameState.IN_PUZZLE, GameState.WIN),
            new(GameState.IN_PUZZLE, GameState.LOSE),
            };
    }


    private void Update()
    {
        StateStay(); 
    }


    // the one to be messed with by other scripts 
    public void ChangeState(GameState newState)
    {
        // dont allow redundant transitions 
        if (GameState == newState) return; 
            
        if (allowedTransitions.Contains(new(GameState, newState)))
        {
            StateExit();
            GameState = newState;
            StateEnter(); 
        }
    }


    // handling the actual state logic 
    private void StateEnter()
    {
        switch (GameState)
        {
            case GameState.START_SCREEN:
                // start behavior 
                break;

            case GameState.IN_PUZZLE:
                break;

            case GameState.WIN:
                break;

            case GameState.LOSE:
                break;
        }
    }

    private void StateStay()
    {
        switch (GameState)
        {
            case GameState.START_SCREEN:
                // start behavior 
                break;

            case GameState.IN_PUZZLE:
                break;

            case GameState.WIN:
                break;

            case GameState.LOSE:
                break;
        }
    }

    private void StateExit()
    {
        switch (GameState)
        {
            case GameState.START_SCREEN:
                // start behavior 
                break;

            case GameState.IN_PUZZLE:
                break;

            case GameState.WIN:
                break;

            case GameState.LOSE:
                break;
        }
    }
}
