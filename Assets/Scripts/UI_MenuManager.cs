using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] Animator CrossFade;
    [SerializeField] float transitionTime = 0.3f;

    // GAME - Go to Game scene
    public void PlayGameSolo()
    {
        LoadNextLevel("Game-Solo", transitionTime);
        PlayerPrefs.SetInt("WinsO", 0);
        PlayerPrefs.SetInt("WinsX", 0);

        PlayerPrefs.SetInt("temp_RoundsPlayed_Solo", 0);
    }

    // GAME - Go to Game scene
    public void PlayGameDuos()
    {
        LoadNextLevel("Game-Duos", transitionTime);
        PlayerPrefs.SetInt("WinsO", 0);
        PlayerPrefs.SetInt("WinsX", 0);

        PlayerPrefs.SetInt("temp_RoundsPlayed_Duos", 0);
    }

    // RETRY GAME DUOS - Go to Game scene
    public void RetryGameDuos()
    {
        LoadNextLevel("Game-Duos", transitionTime);

        PlayerPrefs.SetInt("temp_RoundsPlayed_Duos", PlayerPrefs.GetInt("temp_RoundsPlayed_Duos") + 1);

        if (!PlayerPrefs.HasKey("Rounds_Duos"))
        {
            PlayerPrefs.SetInt("Rounds_Duos", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("temp_RoundsPlayed_Duos") > PlayerPrefs.GetInt("Rounds_Duos"))
            {
                PlayerPrefs.SetInt("Rounds_Duos", PlayerPrefs.GetInt("temp_RoundsPlayed_Duos"));
            }
        }

        Debug.Log("temp: " + PlayerPrefs.GetInt("temp_RoundsPlayed_Duos").ToString());
        Debug.Log("set: " + PlayerPrefs.GetInt("Rounds_Duos"));
    }

    // RETRY GAME SOLO - Go to Game scene
    public void RetryGameSolo()
    {
        LoadNextLevel("Game-Solo", transitionTime);

        PlayerPrefs.SetInt("temp_RoundsPlayed_Solo", PlayerPrefs.GetInt("temp_RoundsPlayed_Solo") + 1);

        if (!PlayerPrefs.HasKey("Rounds_Solo"))
        {
            PlayerPrefs.SetInt("Rounds_Solo", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("temp_RoundsPlayed_Solo") > PlayerPrefs.GetInt("Rounds_Solo"))
            {
                PlayerPrefs.SetInt("Rounds_Solo", PlayerPrefs.GetInt("temp_RoundsPlayed_Solo"));
            }
        }

        Debug.Log("temp: " + PlayerPrefs.GetInt("temp_RoundsPlayed_Solo").ToString());
        Debug.Log("set: " + PlayerPrefs.GetInt("Rounds_Solo"));
    }

    // MORE - Go to Menu-More scene
    public void GoToMore()
    {
        LoadNextLevel("Menu-More", transitionTime);
    }

    // Exit - Exit/Close game
    public void ExitGame()
    {
        StartCoroutine(ExitApplication(0.4f));
        PlayerPrefs.SetInt("WinsO", 0);
        PlayerPrefs.SetInt("WinsX", 0);

    }

    // BACK - Return to Main-Mennu
    public void ReturnToMain()
    {
        LoadNextLevel("Menu-Main", transitionTime);
    }

    // More-Menu: Clear Stats
    public void ClearStats()
    {
        // Duos Stats
        PlayerPrefs.SetInt("Rounds_Duos", 0);
        PlayerPrefs.SetInt("temp_RoundsPlayed_Duos", 0);
        PlayerPrefs.SetInt("WinsO_Duos", 0);
        PlayerPrefs.SetInt("WinsX_Duos", 0);

        // Solo Stats
        PlayerPrefs.SetInt("Rounds_Solo", 0);
        PlayerPrefs.SetInt("temp_RoundsPlayed_Solo", 0);
        PlayerPrefs.SetInt("WinsO_Solo", 0);
        PlayerPrefs.SetInt("WinsX_Solo", 0);

        // Open Scene Again
        SceneManager.LoadScene("Menu-More");
    }

    public void LoadNextLevel(string SceneName, float transitionTime)
    {
        StartCoroutine(LoadLevel(SceneName, transitionTime));
    }

    IEnumerator LoadLevel(string SceneName, float transitionTime)
    {
        // Play animation
        CrossFade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneName);
    }

    IEnumerator ExitApplication(float transitionTime)
    {
        // Play animation
        CrossFade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Debug.LogWarning("Quit");
        Application.Quit();
    }
}
