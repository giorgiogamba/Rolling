using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasspartoutController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I)) {
            Camera.main.GetComponent<FinalLevelPlaneController>().UnlockLevel();
        }       
    }
}
