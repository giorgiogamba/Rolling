using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

class LevelLoader : MonoBehaviour {
    public Animator transition;
    public int transitionTime;

    void Update () {
        //if si avvera la condizione per il passaggio al prossimo livello
        if (Input.GetKey(KeyCode.C)) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}