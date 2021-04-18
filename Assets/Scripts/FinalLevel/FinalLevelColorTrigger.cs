using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelColorTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {    
        GameObject parent = transform.parent.gameObject;
        if (Camera.main.GetComponent<FinalLevelController>().CheckColor(parent.GetComponent<Renderer>().material)) {
            GetComponent<Collider>().isTrigger = false;
            Debug.Log("Color Checked");
        }
    }
}
