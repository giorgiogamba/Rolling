using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public LevelLoader ll;
    public bool disabled;

    public void OnTriggerEnter(Collider other) {
        if (!disabled) {
            GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Collider>().isTrigger = false;
            ll.LoadNextLevel();
        }
    }
}
