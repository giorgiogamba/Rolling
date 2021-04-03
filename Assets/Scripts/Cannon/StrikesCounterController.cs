using System.Collections;
using System.Collections.Generic;
//using System.Convert;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StrikesCounterController : MonoBehaviour
{

    public int count;
    public int total;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        text = GetComponent<TMP_Text>();
        if (text == null) {
            Debug.Log("NUllo");
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = System.Convert.ToString(count) + " OUT OF " + System.Convert.ToString(total);
        if (count == total) {
            Camera.main.GetComponent<TimeBarController>().Completed();
        }
    }

    public void UpdateStrike() {
        count ++;
    }
}
