using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[Serializable]
public class SavePuzzleProgress : Puzzle_SearchBar
{
    private static readonly string PPDELIM = ";";

    //private void Start()
    //{
    //    PlayerPrefs.SetString("savegame", JsonUtility.ToJson(this));
    //    var savedGame = PlayerPrefs.GetString("savegame", "");
    //    if (!string.IsNullOrEmpty(savedGame))
    //    {
    //        var savedObj = JsonUtility.FromJson<SavePuzzleProgress>(savedGame);
    //    }
    //}

    public void Save()
    {
        string puzzleSet = "";
        foreach (var puzzle in PuzzleManager.completedPuzzles)
        {
            puzzleSet += puzzle + PPDELIM;
        }
        PlayerPrefs.SetString("sg_completedpuzzles", puzzleSet);
        print("Saved data to PlayerPrefs");

        // saving active puzzle index - 1 
        if (PuzzleManager.Instance != null && PuzzleManager.Instance.puzzles != null)
        {
            for (int i = 0; i < PuzzleManager.Instance.puzzles.Count; i++)
            {
                var p = PuzzleManager.Instance.puzzles[i]; 
                // finding currently active puzzle in heirarchy 
                if ( p != null && p.gameObject.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("sg_activeindex", i);
                    PlayerPrefs.Save();
                    print($"Saved puzzle index: {i}");
                    return; 
                }
            }

            PlayerPrefs.SetInt("sg_activeindex", -1);
            PlayerPrefs.Save();
            print("Saved no active puzzle -1"); 
        }
        

    }

    public void Load()
    {
        // grabbing the saved puzzles and splitting them by the delim 
        if (PlayerPrefs.HasKey("sg_completedpuzzles"))
        {
            // string with delims still in place 
            string savedData = PlayerPrefs.GetString("sg_completedpuzzles");
            string[] splitPuzzles = savedData.Split(new string[] { PPDELIM }, StringSplitOptions.RemoveEmptyEntries);
            PuzzleManager.completedPuzzles = new HashSet<string>(splitPuzzles);
            print("Loaded data from PlayerPrefs"); 
        }
    }
}
