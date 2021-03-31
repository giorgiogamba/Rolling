using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        GetComponent<Renderer>().material.color = Color.red;
        GetComponent<Collider>().isTrigger = false;
    }
}
