using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public bool enabled = true;

    public void OnTriggerEnter(Collider other)
    {
        if (enabled) {
            GameObject parent = transform.parent.gameObject;
            if (Camera.main.GetComponent<ColorsController>().CheckColor(parent.GetComponent<Renderer>().material)) {
                GetComponent<Collider>().isTrigger = false;
                Debug.Log("Color Checked");
            }
        }
    }
}
