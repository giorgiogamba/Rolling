using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public string levelPath;
    public string gameName;
    public LevelLoader levelLoader;
    public Material trophyMat;
    public bool enabled = true;

    void OnTriggerStay(Collider other) {
        if (enabled) {
            transform.parent.position = new Vector3(transform.parent.position.x, -0.199f, transform.parent.position.z);
            //levelLoader.LoadLevelName(levelName, level, true);
            levelLoader.LoadLevelFromHUB(levelPath, gameName);
        }
    }

    public void Completed() {
        GetComponent<Renderer>().material = trophyMat;
    }

    public void SetEnabled(bool value) {
        enabled = value;
    }
}
