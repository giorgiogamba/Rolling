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
            //SelectText("Entrance", true); //activating entrance canvas text
            //SelectText("Exit", false); //deactivating exit canvas text
            textEntrance.SetActive(true);
            if (textExit != null) {
                textExit.SetActive(false);
            }
        }
    }

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

    public void ReturnToHub() {
        //SelectText("Entrance", false);
        textEntrance.SetActive(false);
        StartCoroutine(LoadLevelNameCoroutine("Scenes/Levels/HUB/1_HUB"));
    }

    public void LoadLevelName(string levelPath) {
        //StartCoroutine(LoadLevelNameCoroutine(levelName, level, selectText));
        //SelectText("Entrance", false);
        //SelectText("Exit", true);
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