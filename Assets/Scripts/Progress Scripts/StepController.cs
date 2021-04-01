using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public LevelLoader ll;
    public float waitTime = 3f;
    public bool disabled;

    public void OnTriggerEnter(Collider other) {
        if (!disabled) {
            StartCoroutine(WaitForLoading());
            GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Collider>().isTrigger = false;
            ll.LoadNextLevel();
        }
    }

    IEnumerator WaitForLoading() {
        yield return new WaitForSeconds(waitTime);
    }
}
