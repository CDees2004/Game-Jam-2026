using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class SavePuzzleProgress : Puzzle_SearchBar
{

    private void Start()
    {
        PlayerPrefs.SetString("savegame", JsonUtility.ToJson(this));
        var savedGame = PlayerPrefs.GetString("savegame", "");
        if (!string.IsNullOrEmpty(savedGame))
        {
            var savedObj = JsonUtility.FromJson<SavePuzzleProgress>(savedGame);
        }
    }

    private void Update()
    {
        
    }
}
