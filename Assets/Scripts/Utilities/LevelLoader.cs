using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public Animator transition;
    public float transitionTime; //tempo che èassa prima che venga caricata la prossima scena
    public bool disableTexts = false;

    public GameObject textEntrance;
    public GameObject textExit;

    void Start() {
        Debug.Log("Level Load Started");
        if (disableTexts) {
            DisableTexts();
        } else{
            textEntrance.SetActive(true);
            if (textExit != null) {
                textExit.SetActive(false);
            }
        }
    }
    public void LoadNextLevel() {
        if (Scoring.GetTries() > 0) {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        } else {
            Debug.Log("End of the number of tries");
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    //Called when the player loses
    public void TryAgain() {
        if (Scoring.GetTries() > 0) { //Calling the same scene
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        } else { //Calling Restart Menu
            Debug.Log("End of the number of tries");
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Scenes/Levels/UI/2_restart");
    }

    public void ReturnToHub() {
        textEntrance.SetActive(false);
        StartCoroutine(LoadLevelNameCoroutine("Scenes/Levels/HUB/1_HUB"));
    }

    public void LoadLevelName(string levelPath) {
        textEntrance.SetActive(false);
        textExit.SetActive(true);
        StartCoroutine(LoadLevelNameCoroutine(levelPath));
    }

    public void LoadLevelFromHUB(string levelPath, string gameName) {
        SelectText(gameName, true);
        StartCoroutine(LoadLevelNameCoroutine(levelPath));
    }

    IEnumerator LoadLevelNameCoroutine(string levelName) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

    //Selects a canvas text with name "Text_level" and activates or not it depending on op
    private void SelectText(string level, bool op) {
        GameObject cw = transform.Find("CircleWipe").gameObject;
        if (cw != null) {
            GameObject image = cw.transform.Find("Image").gameObject;
            if (image != null) {
                string temp = "Texts_"+level;
                GameObject go = image.transform.Find(temp).gameObject;
                go.SetActive(op);
            }   
        }
    }

    //Disable all canvas Texts
    public void DisableTexts() {
        GameObject cw = transform.Find("CircleWipe").gameObject;
        if (cw != null) {
            GameObject image = cw.transform.Find("Image").gameObject;
            if (image != null) {
                foreach(Transform child in image.transform) {
                    child.gameObject.SetActive(false);
                }
            }    
        }
    }
}