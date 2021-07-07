using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;
using TMPro;

public class TimeBarController : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject message;
    public GameObject completed_message;
    public GameObject player;
    private GameObject outOfTheFieldMessage;
    public LevelLoader ll;
    private int actionid;
    private bool doneManageFailure = false;
    private LTDescr descr;
    
    void Start()
    {
        SetScore();
        Debug.Log(bar.GetType());
        message.SetActive(false);
        completed_message.SetActive(false);

        Transform tbc = bar.transform.parent.parent;
        outOfTheFieldMessage = tbc.Find("OutOfTheFieldMessage").gameObject;
        if (outOfTheFieldMessage != null) {
            outOfTheFieldMessage.SetActive(false);
        } else {
            Debug.Log("TimeBarController: outOfTheFieldMessage is null");
        }
        AnimateBar();
    }

    void Update() {
        Transform sphere = player.transform.Find("Sphere");
        if (sphere != null && (sphere.position.y < -5f)) {
            if (doneManageFailure == false) {
                StartCoroutine(OutOfTheFieldRoutine());
                doneManageFailure = true;
            }
        }

        //try
        float remainedTime = descr.time - descr.passed;
        if (remainedTime < 10) {
            bar.GetComponent<Image>().color = Color.red;
        }
    }

    IEnumerator OutOfTheFieldRoutine() {
        LeanTween.cancel(actionid); //locking bar movement
        showOutOfTheFieldMessage();
        yield return new WaitForSeconds(1);
        ManageFailure();
    }

    public void AnimateBar() {
        //actionid = LeanTween.scaleX(bar, 0, time).setOnComplete(showMessage).id;
        
        descr = LeanTween.scaleX(bar, 0, time).setOnComplete(showMessage);
        actionid = descr.id;
    }

    private void showOutOfTheFieldMessage() {
        outOfTheFieldMessage.SetActive(true);
    }

    private void showMessage() {
        message.SetActive(true);

        //Locking player movements
        GameObject sphere = player.transform.Find("Sphere").gameObject;
        if (sphere != null) {
            sphere.GetComponent<PlayerController>().enabled = false;
            sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        ManageFailure();
    }

    private void ManageFailure() {
        Scoring.LoseTry();
        Debug.Log("ManageFailure -- tries rimasti: "+Scoring.GetTries());
        Debug.Log("try deleted - ManageFailure");
        ll.TryAgain();
    }

    public void Completed() {
        completed_message.SetActive(true);
        LeanTween.cancel(actionid);
    }

    private void SetScore() {
        
        //Getting Object TimeBarController
        Transform tbc = bar.transform.parent.parent;

        if (tbc != null) {
            Transform scoringObjects = tbc.Find("ScoringTitle");
            if (scoringObjects != null) {
                GameObject score = scoringObjects.Find("Score").gameObject;
                if (score != null) {

                    TMP_Text tmpScore = score.GetComponent<TMP_Text>();

                    //Setting up the text
                    int actualScore = Scoring.GetTries();
                    tmpScore.text = System.Convert.ToString(actualScore) + " OUT OF 3";
                } else {
                    Debug.Log("Score è nullo");
                }
            } else {
                Debug.Log("ScoringTitle è nullo");
            }
        } else {
            Debug.Log("bar è null");
        }
    }
}
