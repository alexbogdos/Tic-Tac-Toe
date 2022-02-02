using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_ButtonController : MonoBehaviour
{
    [SerializeField] Game_PlayersController PlayersController;
    string buttonName;
    TMP_Text text;
    Animator animator;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        buttonName = this.gameObject.name;
        PlayersController.UnusedButtonsList.Add(buttonName);
        animator = GetComponent<Animator>();
    }

    public void ChangeButton()
    {   
        // Sort the unused buttons list
        PlayersController.UnusedButtonsList.Sort();

        if (PlayersController.GameState == "PLAYING")
        {
            if (text.text == "")
            {
                // Show button text x/o, count it, add the button name to it's list
                if (PlayersController.PlayerPlaying == 'x')
                {
                    text.text = "x";
                    animator.SetTrigger("Tapped");
                    PlayersController.PlayerPlaying = 'o';
                    PlayersController.TimesXPlayed++;
                    PlayersController.PlayerXbuttons.Add(buttonName);
                }
                else if (PlayersController.PlayerPlaying == 'o')
                {
                    text.text = "o";
                    animator.SetTrigger("Tapped");
                    PlayersController.PlayerPlaying = 'x';
                    PlayersController.TimesOPlayed++;
                    PlayersController.PlayerObuttons.Add(buttonName);
                }
                PlayersController.UnusedButtonsList.Remove(buttonName);

                if (PlayersController.TimesXPlayed >= 3)
                {
                    CheckForWin();
                }
            }
            else
            {
                Debug.LogError("Filled");
            }
        }
    }

    public void CheckForWin ()
    {
        var PlayerXbuttons = PlayersController.PlayerXbuttons;
        PlayerXbuttons.Sort();
        var PlayerObuttons = PlayersController.PlayerObuttons;
        PlayerObuttons.Sort();

        foreach (var combination in PlayersController.combinations)
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
                PlayersController.Winner = 'x';
                PlayersController.GameState = "FINISHED";
                PlayersController.WinningCombination = combination[0] + "=" + combination[2];
                int WinsX = PlayerPrefs.GetInt("WinsX");
                WinsX++;
                PlayerPrefs.SetInt("WinsX", WinsX);

                if (SceneManager.GetActiveScene().name.Equals("Game-Duos"))
                {
                    if (WinsX > PlayerPrefs.GetInt("WinsX_Duos"))
                    {
                        PlayerPrefs.SetInt("WinsX_Duos", WinsX);
                    }
                }
                else if (SceneManager.GetActiveScene().name.Equals("Game-Solo"))
                {
                    if (WinsX > PlayerPrefs.GetInt("WinsX_Solo"))
                    {
                        PlayerPrefs.SetInt("WinsX_Solo", WinsX);
                    }
                }

                break;
            }
            else if (countO == 3) 
            {
                PlayersController.Winner = 'o';
                PlayersController.GameState = "FINISHED";
                PlayersController.WinningCombination = combination[0] + "=" + combination[2];
                int WinsO = PlayerPrefs.GetInt("WinsO");
                WinsO++;
                PlayerPrefs.SetInt("WinsO", WinsO);

                if (SceneManager.GetActiveScene().name.Equals("Game-Duos"))
                {
                    if (WinsO > PlayerPrefs.GetInt("WinsO_Duos"))
                    {
                        PlayerPrefs.SetInt("WinsO_Duos", WinsO);
                    }
                }

                break;
            }
        }

    }
}


