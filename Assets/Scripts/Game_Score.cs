using UnityEngine;
using TMPro;

public class Game_Score : MonoBehaviour
{
    [SerializeField] char FollowedPlayer;
    [SerializeField] Game_PlayersController PlayersController;

    TMP_Text text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        if (FollowedPlayer == 'x')
        {
            score = PlayerPrefs.GetInt("WinsX");
            text.text = "x - " + (score.ToString());
        }
        else if (FollowedPlayer == 'o')
        {
            score = PlayerPrefs.GetInt("WinsO");
            text.text = "o - " + (score.ToString());
        }
    }

    /*void FixedUpdate()
    {
        if (FollowedPlayer == 'x')
        {
            if (score != PlayersController.TimesXPlayed)
            {
                score = PlayersController.TimesXPlayed;
                text.text = "x - " + (score.ToString());
            }
        }
        else if (FollowedPlayer == 'o')
        {
            score = PlayersController.TimesOPlayed;
            text.text = "o - " + (score.ToString());
        }
    }*/
}
