using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesColorController : MonoBehaviour
{
    public LevelLoader ll;
    public List<GameObject> planes;
    private int totplanes;
    public bool returnToHUB = false;
    public string nextLevelPath;

    // Start is called before the first frame update
    void Start()
    {
        totplanes = planes.Count;
        if (planes.Count == 0) {
            Debug.LogError("PlanesColorController: planes count is 0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int j = 0; j < planes.Count; j++) {
            if (planes[j].GetComponent<Renderer>().material.color == Color.black)
            {
                count++;
            }
        }

        if (count == totplanes)
        {
            Debug.Log("END");
            GetComponent<TimeBarController>().Completed();
            for (int j = 0; j < planes.Count; j++) {
                planes[j].GetComponent<PlaneController>().enabled = false;
                
                //making planes yellow
                Material mat = planes[j].GetComponent<Renderer>().material;
                mat.color = Color.yellow;
            }
            if (returnToHUB) {
                Trophies.TrophyCompleted("ColorRun");
                ll.ReturnToHub();
            } else {
                ll.LoadLevelName(nextLevelPath);
            }
        }
    }
}
