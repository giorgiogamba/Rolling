using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public LevelLoader levelLoader;
    public TimeBarController timeBarController;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Obiettivo Raggiunto!");
        timeBarController.Completed();
        levelLoader.LoadNextLevel();
    }
}
