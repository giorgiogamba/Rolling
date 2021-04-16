using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public LevelLoader levelLoader;
    public TimeBarController timeBarController;
    public List<Transform> spawn_points;
    public string nextLevelPath;
    public bool returnToHUB = false;

    public string gameName;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Obiettivo Raggiunto!");
        timeBarController.Completed();
        if (returnToHUB) {
            Trophies.TrophyCompleted(gameName);
            Debug.Log("HO chiamato");
            levelLoader.ReturnToHub();
        } else {
            levelLoader.LoadLevelName(nextLevelPath);
        }
    }

    private void Start() {
        //Spawn();
    }

    /*private void Spawn() {
        System.Random randgen = new System.Random();
        int index = randgen.Next(0, spawn_points.Count - 1);
        Debug.Log("Indice generato"+index);
        Debug.Log("transform vale: "+transform.position);
        transform.position = spawn_points[index].position;
        Debug.Log("spawn vale: "+spawn_points[index].position);
    }*/
}