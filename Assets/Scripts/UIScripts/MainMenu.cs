using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Scoring.ResetTries();
        Debug.Log("Numero tentativi: "+Scoring.GetTries());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Scenes/Levels/HUB/1_HUB");
    }

    public void ExitGame() {
        Debug.Log("Quitted");
        Application.Quit();
    }

    public void PlayAgain() {
        Scoring.ResetTries();
        SceneManager.LoadScene(1);
    }

    public void Commands() {
        SceneManager.LoadScene("4_commands");
    }

    public void Options() {
        SceneManager.LoadScene("5_options");
    }
}
