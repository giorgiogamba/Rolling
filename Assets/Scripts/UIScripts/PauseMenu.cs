using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string sceneName;

    private void Start() {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (PauseController.isEnabled()) {
            if (Input.GetButtonDown("Pause")) {
                Pause();
            }
        }
    }

    private void Pause() {
        PauseController.DisablePause();
        Time.timeScale = 0; //Pausing every movement
        InputManagement.DisableInput(); //Disabling player movements
        SceneManager.LoadScene("3_pause", LoadSceneMode.Additive); //Loading pause UI scene
    }

    public void Resume() {
        SceneManager.UnloadSceneAsync("3_pause"); //Closing pause UI
        Time.timeScale = 1; //Start movements
        InputManagement.EnableInput(); //Enabling character inputs
        PauseController.EnablePause();
    }

    public void BackToHUB() {
        //Closing previous game scene
        SceneManager.UnloadSceneAsync(sceneName);
        Resources.UnloadUnusedAssets();
        Scoring.ResetTries();
        Time.timeScale = 1;
        InputManagement.EnableInput();
        SceneManager.LoadScene("Scenes/Levels/HUB/1_HUB"); //Loading HUB
        PauseController.EnablePause();
    }
}
