using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_AI : MonoBehaviour
{
    [SerializeField] Game_PlayersController PlrsCtrl;

    bool played1;
    bool played2;
    bool played3;
    bool played4;

    // Update is called once per frame
    void Update()
    {
        if (PlrsCtrl.GameState == "PLAYING" || PlrsCtrl.GameState == "WAITING")
        {
            // First round
            if (PlrsCtrl.TimesXPlayed == 1 && PlrsCtrl.TimesOPlayed == 0 && !played1)
            {
                var possibilities = new List<string> { "T-R", "B-L", "B-R", "T-L" };
                var playerXpos = PlrsCtrl.PlayerXbuttons[0];
                possibilities.Remove(playerXpos);
                ChooseOButton(possibilities);

                played1 = true;
            }

            // Second round
            else if (PlrsCtrl.TimesXPlayed == 2 && PlrsCtrl.TimesOPlayed == 1 && !played2)
            {
                var PlayerXbuttons = PlrsCtrl.PlayerXbuttons;
                PlayerXbuttons.Sort();
                bool chose = false;

                foreach (var combination in PlrsCtrl.combinations)
                {
                    int countX = 0;
                    var possibilities = new List<string>();
                    foreach (string i in combination)
                    {
                        if (PlayerXbuttons.Contains(i))
                        {
                            countX++;
                        }
                        else
                        {

                            if (PlrsCtrl.UnusedButtonsList.Contains(i))
                            {
                                possibilities.Add(i);
                            }
                            else
                            {
                                countX--;
                            }
                        }
                    }

                    if (countX == 2)
                    {
                        ChooseOButton(possibilities);
                        Debug.Log("Loop");
                        chose = true;
                        break;
                    }
                }

                if (!chose)
                {
                    ChooseOButton(PlrsCtrl.UnusedButtonsList);
                    Debug.Log("N/A");
                }

                played2 = true;
            }

            // Third round
            else if (PlrsCtrl.TimesXPlayed == 3 && PlrsCtrl.TimesOPlayed == 2 && !played3)
            {
                var PlayerObuttons = PlrsCtrl.PlayerObuttons;
                PlayerObuttons.Sort();
                var PlayerXbuttons = PlrsCtrl.PlayerXbuttons;
                PlayerXbuttons.Sort();

                var possibilities_O = new List<string>();
                var possibilities_X = new List<string>();

                bool chose = false;
                bool choseOnLoop = false;

                foreach (var combination in PlrsCtrl.combinations)
                {
                    int countO = 0;
                    possibilities_O.Clear();
                    foreach (string i in combination)
                    {
                        if (PlayerObuttons.Contains(i))
                        {
                            countO++;
                        }
                        else
                        {
                            if (PlrsCtrl.UnusedButtonsList.Contains(i))
                            {
                                possibilities_O.Add(i);
                            }
                            else
                            {
                                countO--;
                            }
                        }
                    }

                    if (countO == 2)
                    {
                        Debug.Log("O");
                        choseOnLoop = true;
                        ChooseOButton(possibilities_O);
                        chose = true;
                        break;
                    }
                }
                foreach (var combination in PlrsCtrl.combinations)
                {
                    int countX = 0;
                    possibilities_X.Clear();
                    foreach (string i in combination)
                    {
                        if (PlayerXbuttons.Contains(i))
                        {
                            countX++;
                        }
                        else
                        {
                            if (PlrsCtrl.UnusedButtonsList.Contains(i))
                            {
                                possibilities_X.Add(i);
                            }
                            else
                            {
                                countX--;
                            }
                        }
                    }

                    if (countX == 2 && !choseOnLoop)
                    {
                        Debug.Log("X");
                        ChooseOButton(possibilities_X);
                        chose = true;
                        break;
                    }
                    else if (countX == 2)
                    {
                        Debug.LogWarning("Tried");
                    }
                }

                if (!chose)
                {
                    ChooseOButton(PlrsCtrl.UnusedButtonsList);
                    Debug.Log("N/A");
                }

                played3 = true;
            }

            // Fourth round
            else if (PlrsCtrl.TimesXPlayed == 4 && PlrsCtrl.TimesOPlayed == 3 && !played4)
            {
                var PlayerObuttons = PlrsCtrl.PlayerObuttons;
                PlayerObuttons.Sort();
                var PlayerXbuttons = PlrsCtrl.PlayerXbuttons;
                PlayerXbuttons.Sort();

                var possibilities_O = new List<string>();
                var possibilities_X = new List<string>();

                bool chose = false;
                bool choseOnLoop = false;

                foreach (var combination in PlrsCtrl.combinations)
                {
                    int countO = 0;
                    possibilities_O.Clear();
                    foreach (string i in combination)
                    {
                        if (PlayerObuttons.Contains(i))
                        {
                            countO++;
                        }
                        else
                        {
                            if (PlrsCtrl.UnusedButtonsList.Contains(i))
                            {
                                possibilities_O.Add(i);
                            }
                            else
                            {
                                countO--;
                            }
                        }
                    }

                    if (countO == 2)
                    {
                        choseOnLoop = true;
                        Debug.Log("O");
                        ChooseOButton(possibilities_O);
                        chose = true;
                        break;
                    }
                }
                foreach (var combination in PlrsCtrl.combinations)
                {
                    int countX = 0;
                    possibilities_X.Clear();
                    foreach (string i in combination)
                    {
                        if (PlayerXbuttons.Contains(i))
                        {
                            countX++;
                        }
                        else
                        {
                            if (PlrsCtrl.UnusedButtonsList.Contains(i))
                            {
                                possibilities_X.Add(i);
                            }
                            else
                            {
                                countX--;
                            }
                        }
                    }

                    if (countX == 2 && !choseOnLoop)
                    {
                        choseOnLoop = true;
                        Debug.Log("X");
                        ChooseOButton(possibilities_X);
                        chose = true;
                        break;
                    }
                    else if (countX == 2)
                    {
                        Debug.LogWarning("Tried");
                    }
                }

                if (!chose && !choseOnLoop)
                {
                    ChooseOButton(PlrsCtrl.UnusedButtonsList);
                    Debug.Log("N/A");
                }

                played4 = true;
            }
        }
    }

    void ChooseOButton (List<string> possibilities)
    {
        PlrsCtrl.GameState = "WAITING";

        // Make decision for o position
        System.Random random = new System.Random();

        int index = random.Next(0, possibilities.Count);
        var list = FindObjectsOfType<Game_ButtonController>();
        foreach (var button in list)
        {
            if (button.name.Equals(possibilities[index]))
            {
                StartCoroutine(TapButton(button));
                break;
            }
        }
    }

    IEnumerator TapButton(Game_ButtonController button)
    {
        TMP_Text text = button.GetComponentInChildren<TMP_Text>();
        Animator animator = button.GetComponent<Animator>();

        yield return new WaitForSeconds(0.5f);
        text.text = "o";
        animator.SetTrigger("Tapped");
        PlrsCtrl.PlayerPlaying = 'x';
        PlrsCtrl.TimesOPlayed++;
        PlrsCtrl.PlayerObuttons.Add(button.name);
        PlrsCtrl.PlayerPlaying = 'x';
        PlrsCtrl.UnusedButtonsList.Remove(button.name);

        PlrsCtrl.GameState = "PLAYING";

        if (PlrsCtrl.TimesOPlayed >= 3)
        {
            CheckForWin();
        }
        
    }

    void CheckForWin()
    {
        var PlayerXbuttons = PlrsCtrl.PlayerXbuttons;
        PlayerXbuttons.Sort();
        var PlayerObuttons = PlrsCtrl.PlayerObuttons;
        PlayerObuttons.Sort();

        foreach (var combination in PlrsCtrl.combinations)
        {
            int countX = 0;
            int countO = 0;
            foreach (string i in combination)
            {
                if (PlayerXbuttons.Contains(i))
                {
                    countX++;
                }
                else if (PlayerObuttons.Contains(i))
                {
                    countO++;
                }
            }

            if (countX == 3)
            {
                PlrsCtrl.Winner = 'x';
                PlrsCtrl.GameState = "FINISHED";
                PlrsCtrl.WinningCombination = combination[0] + "=" + combination[2];

                int WinsX = PlayerPrefs.GetInt("WinsX");
                WinsX++;
                PlayerPrefs.SetInt("WinsX", WinsX);
                break;
            }
            else if (countO == 3)
            {
                PlrsCtrl.Winner = 'o';
                PlrsCtrl.GameState = "FINISHED";
                PlrsCtrl.WinningCombination = combination[0] + "=" + combination[2];

                int WinsO = PlayerPrefs.GetInt("WinsO");
                WinsO++;
                PlayerPrefs.SetInt("WinsO", WinsO);

                if (SceneManager.GetActiveScene().name.Equals("Game-Solo"))
                {
                    if (WinsO > PlayerPrefs.GetInt("WinsO_Solo"))
                    {
                        PlayerPrefs.SetInt("WinsO_Solo", WinsO);
                    }
                }

                break;
            }
        }

    }
}
