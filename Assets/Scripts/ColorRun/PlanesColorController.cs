using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesColorController : MonoBehaviour
{
    public LevelLoader ll;
    public List<GameObject> planes;
    private int totplanes;

    // Start is called before the first frame update
    void Start()
    {
        totplanes = planes.Count;
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
            Debug.Log("FINE");
            GetComponent<TimeBarController>().Completed();
            for (int j = 0; j < planes.Count; j++) {
                planes[j].GetComponent<PlaneController>().enabled = false;
                
                //making planes yellow
                Material mat = planes[j].GetComponent<Renderer>().material;
                mat.color = Color.yellow;
            }
            ll.LoadNextLevel();
        }
    }
}
