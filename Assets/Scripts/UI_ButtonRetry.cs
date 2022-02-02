using UnityEngine;

public class UI_ButtonRetry : MonoBehaviour
{
    [SerializeField] Game_PlayersController PlayersController;
    [SerializeField] GameObject ButtonRetry;


    void Update()
    {
        if (PlayersController.TimesXPlayed >= 5)
        {
            ButtonRetry.SetActive(true);
        }
        else if (PlayersController.GameState == "FINISHED")
        {
            ButtonRetry.SetActive(true);
        }
    }
}
