using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    //Setuo GameObject as trigger
    //Ends the level when triggered

    void OnTriggerEnter(Collider ohter) {
        Debug.Log("END GAME");

        //Make the game stop
        Camera.main.GetComponent<TimeBarController>().Completed();
    }
}
