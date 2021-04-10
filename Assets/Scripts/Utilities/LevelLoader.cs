using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public Animator transition;
    public float transitionTime; //tempo che èassa prima che venga caricata la prossima scena

    void Update () {
        //if si avvera la condizione per il passaggio al prossimo livello
        if (Input.GetKey(KeyCode.C)) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        if (Scoring.GetTries() > 0) {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        } else {
            Debug.Log("End of the number of tries");
            //Richiamo della scena di restart
        }
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    //Called when the player loses
    public void TryAgain() {
        Debug.Log("Sono dentro il LevelLoader");
        if (Scoring.GetTries() > 0) {
            //Richiamo della stessa scena
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            Debug.Log("Ho richiamato la stessa scena");
        } else {
            Debug.Log("End of the number of tries");
            //Richiamo della scena di restart
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel() {
        transition.SetTrigger("Start");
        Debug.Log("Ho fatto partire l'anumazione");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Ricarico");
        SceneManager.LoadScene("Scenes/Levels/UI/2_restart");
    }
}