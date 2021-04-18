using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trophies : MonoBehaviour
{
    public static List<Tuple<string, int>> trophies = new List<Tuple<string, int>>();
    public List<GameObject> planes;
    public Material trophyMaterial;

    public static void Initialize() {
        trophies.Add(new Tuple<string, int>("ColorRun", 0));
        trophies.Add(new Tuple<string, int>("Ball", 0));
        trophies.Add(new Tuple<string, int>("Couples", 0));
        trophies.Add(new Tuple<string, int>("AtoB", 0));
        trophies.Add(new Tuple<string, int>("ColorOrder", 0));
        Debug.Log("Trophies Initialized");
    }

    public void PrintList() {
        for (int i = 0; i < trophies.Count; i ++) {
            Debug.Log(trophies[i].Item1 + " -- "+ trophies[i].Item2);
        }
    }
    public void Start() {
        for (int i = 0; i < planes.Count; i ++) {
            SetTrophy(planes[i]);
        }
    }

    private void SetTrophy(GameObject plane) {
        for (int j = 0; j < trophies.Count; j ++) {
            string tempname = "Platform_"+trophies[j].Item1;
            if (Equals(plane.name, tempname)) {
                if (trophies[j].Item2 == 1) {
                    plane.GetComponent<Renderer>().material = trophyMaterial;
                }
            }
        }
    }

    public static void TrophyCompleted(string gameName) {
        for (int j = 0; j < trophies.Count; j ++) {
            if (Equals(gameName, trophies[j].Item1)) {
                trophies.Remove(trophies[j]);
                trophies.Add(new Tuple<string, int>(gameName, 1));
                Debug.Log("Trophy Completed");
            }
        }

        if (trophies.Count == 0) {
            Debug.Log("Trophies have not been initialized");
        }

        //Checking if unlock the last level
        int counter = 0;
        for (int j = 0; j < trophies.Count; j ++) {
            if (trophies[j].Item2 == 1) {
                counter ++;
            }
        }

        if (counter == trophies.Count) {
            Debug.Log("Final Level Unlocked!");
            Camera.main.GetComponent<FinalLevelPlaneController>().UnlockLevel();
        }
    }
}
