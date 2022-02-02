using UnityEngine;
using TMPro;

public class UI_HighScores_Duos : MonoBehaviour
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
        if (!PlayerPrefs.HasKey("Rounds_Duos"))
        {
            PlayerPrefs.SetInt("Rounds_Duos", 0);
        }
        if (!PlayerPrefs.HasKey("WinsO_Duos"))
        {
            PlayerPrefs.SetInt("WinsO_Duos", 0);
        }
        if (!PlayerPrefs.HasKey("WinsX_Duos"))
        {
            PlayerPrefs.SetInt("WinsX_Duos", 0);
        }

        // Most rounds text
        rounds.text = PlayerPrefs.GetInt("Rounds_Duos").ToString();
        rounds_shadow.text = PlayerPrefs.GetInt("Rounds_Duos").ToString();

        // Most player o wins
        WinsO.text = PlayerPrefs.GetInt("WinsO_Duos").ToString();
        WinsO_shadow.text = PlayerPrefs.GetInt("WinsO_Duos").ToString();

        // Most player x wins
        WinsX.text = PlayerPrefs.GetInt("WinsX_Duos").ToString();
        WinsX_shadow.text = PlayerPrefs.GetInt("WinsX_Duos").ToString();
    }
}
