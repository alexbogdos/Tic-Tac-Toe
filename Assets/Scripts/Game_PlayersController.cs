using UnityEngine;
using System.Collections.Generic;

public class Game_PlayersController : MonoBehaviour
{
    internal char PlayerPlaying = 'x';
    internal int TimesXPlayed = 0;
    internal int TimesOPlayed = 0;
    internal string GameState = "PLAYING";
    internal char Winner = ' ';
    internal string WinningCombination = "";

    internal List<string> UnusedButtonsList = new List<string>();
    internal List<string> PlayerXbuttons = new List<string>();
    internal List<string> PlayerObuttons = new List<string>();

    internal List<List<string>> combinations = new List<List<string>>();

    void Awake()
    {
        // Adding all the possible combinations to the combination list
        combinations.Add(new List<string> { "B-L", "M-L" , "T-L"});
        combinations.Add(new List<string> { "B-M", "M-M", "T-M" });
        combinations.Add(new List<string> { "B-R", "M-R", "T-R" });

        combinations.Add(new List<string> { "B-L", "B-M", "B-R" });
        combinations.Add(new List<string> { "M-L", "M-M", "M-R" });
        combinations.Add(new List<string> { "T-L", "T-M", "T-R" });

        combinations.Add(new List<string> { "B-L", "M-M", "T-R" });
        combinations.Add(new List<string> { "B-R", "M-M", "T-L" });
    }
}
