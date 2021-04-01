using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SetupGameObject as trigger
//Ends the level when triggered
[RequireComponent(typeof(LevelLoader))]
public class ObjectiveController : MonoBehaviour
{

    public LevelLoader ll;

    void OnTriggerEnter(Collider ohter) {
        Debug.Log("END GAME");

        //Make the game stop
        Camera.main.GetComponent<TimeBarController>().Completed();

        //Richiamo del Level Loader che carica il prossimo livello
        ll.LoadNextLevel();

    }
}
