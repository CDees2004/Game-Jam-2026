using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    // singleton because manager script
    public static UIManager Instance { get; private set; }

    // main UI elements 
    // set in inspector 
    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject startPlayButton;
    public GameObject startQuitButton;

    public GameObject winPlayButton;
    public GameObject winQuitButton;

    public GameObject losePlayButton;
    public GameObject loseQuitButton;

    private void Start()
    {
        Instance = this; 
        // wiring the buttons 

        // start screen buttons
        if (startPlayButton != null)
        {
            Button startPlay = startPlayButton.GetComponent<Button>();
            startPlay.onClick.AddListener(StartGame);
        }

        if (startQuitButton != null)
        {
            Button startQuit = startQuitButton.GetComponent<Button>();
            startQuit.onClick.AddListener(QuitGame);
        }

        // win screen buttons 
        if (winPlayButton != null)
        {
            Button winPlay = winPlayButton.GetComponent<Button>();
            winPlay.onClick.AddListener(RestartGame);
        }

        if (winQuitButton != null)
        {
            Button winQuit = winQuitButton.GetComponent<Button>();
            winQuit.onClick.AddListener(QuitGame);
        }

        // lose screen buttons
        if (losePlayButton != null)
        {
            Button losePlay = losePlayButton.GetComponent<Button>();
            losePlay.onClick.AddListener(RestartGame);
        }

        if (loseQuitButton != null)
        {
            Button loseQuit = loseQuitButton.GetComponent<Button>();
            loseQuit.onClick.AddListener(QuitGame);
        }

    }

    // progresses to playing state and moves past 
    // the main menu
    private void StartGame()
    {
        // progress them to the puzzle and disable the main menu UI panel
        GameManager.Instance.ChangeState(FsmGameState.IN_PUZZLE);
        startScreen.SetActive(false);
    }

    // functions by reloading the scene
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
#else
    Application.Quit(); 
#endif 
    }
}
