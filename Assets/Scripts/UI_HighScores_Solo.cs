using UnityEngine;
using TMPro;

public class UI_HighScores_Solo : MonoBehaviour
{
    [SerializeField] TMP_Text rounds;
    [SerializeField] TMP_Text rounds_shadow;
    [SerializeField] TMP_Text WinsO;
    [SerializeField] TMP_Text WinsO_shadow;
    [SerializeField] TMP_Text WinsX;
    [SerializeField] TMP_Text WinsX_shadow;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Rounds_Solo"))
        {
            PlayerPrefs.SetInt("Rounds_Solo", 0);
        }
        if (!PlayerPrefs.HasKey("WinsO_Solo"))
        {
            PlayerPrefs.SetInt("WinsO_Solo", 0);
        }
        if (!PlayerPrefs.HasKey("WinsX_Solo"))
        {
            PlayerPrefs.SetInt("WinsX_Solo", 0);
        }

        // Most rounds text
        rounds.text = PlayerPrefs.GetInt("Rounds_Solo").ToString();
        rounds_shadow.text = PlayerPrefs.GetInt("Rounds_Solo").ToString();

        // Most player o wins
        WinsO.text = PlayerPrefs.GetInt("WinsO_Solo").ToString();
        WinsO_shadow.text = PlayerPrefs.GetInt("WinsO_Solo").ToString();

        // Most player x wins
        WinsX.text = PlayerPrefs.GetInt("WinsX_Solo").ToString();
        WinsX_shadow.text = PlayerPrefs.GetInt("WinsX_Solo").ToString();
    }
}
