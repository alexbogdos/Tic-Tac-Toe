using UnityEngine;
using TMPro;

public class Game_Winner : MonoBehaviour
{
    [SerializeField] Game_PlayersController PlayersController;
    [SerializeField] GameObject ScoreCounter;
    [SerializeField] GameObject WinnerTittle;
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text textShadow;

    bool done = false;

    void Update()
    {
        if (!done && PlayersController.GameState.Equals("FINISHED"))
        {
            ScoreCounter.SetActive(false);
            WinnerTittle.SetActive(true);

            text.text = "Player " + PlayersController.Winner + " Won!!";
            textShadow.text = "Player " + PlayersController.Winner + " Won!!";

            done = true;
        }
    }
}
