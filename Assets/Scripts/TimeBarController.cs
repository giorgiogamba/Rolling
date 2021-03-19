using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class TimeBarController : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject message;
    public GameObject completed_message;

    private int actionid;

    // Start is called before the first frame update
    void Start()
    {
        message.SetActive(false);
        completed_message.SetActive(false);
        AnimateBar();
    }

    public void AnimateBar() {
        actionid = LeanTween.scaleX(bar, 0, time).setOnComplete(showMessage).id;
    }

    private void showMessage() {
        message.SetActive(true);
    }

    public void Completed() {
        completed_message.SetActive(true);
        LeanTween.cancel(actionid);
    }
}
