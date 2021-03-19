using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public 
    Camera cam;

    public void OnTriggerEnter(Collider other)
    {

        GameObject parent = transform.parent.gameObject;
        cam.GetComponent<ColorsController>().CheckColor(parent.GetComponent<Renderer>().material);

        GetComponent<Collider>().isTrigger = false;

    }
}
