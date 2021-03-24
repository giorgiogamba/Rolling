using System.Collections;
using System.Collections.Generic;
//using System.Convert;
using UnityEngine;
using UnityEngine.UI;

public class StrikesCounterController : MonoBehaviour
{

    public int count;
    public int total;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = System.Convert.ToString(count) + "/" + System.Convert.ToString(total);
    }

    public void UpdateStrike() {
        count ++;
    }
}
