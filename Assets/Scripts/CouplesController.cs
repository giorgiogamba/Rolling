using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionsMethods;

public class CouplesController : MonoBehaviour
{
    public LevelLoader levelLoader;
    public List<GameObject> objects; //total elements in the scene
    public List<Material> materials; //materials assigned to the couple elements in "objects"
                                     //materials list size is objects/2
    private List<GameObject> buffer;
    private int totcouples = 0;
    private int totobjects;
    private bool stop;
    public bool returnToHUB = false;
    public string nextLevelPath;

    void Start()
    {
        stop = false;
        totobjects = objects.Count;
        totcouples = objects.Count / 2;
        buffer = new List<GameObject>();
        InitializeCouples();
    }

    void Update()
    {
        //When an object in objects is triggered, it inserts itself into buffer
        //When there are two elements into the buffer, they have to be checked
        if (buffer.Count == 2 && !stop) {

            //Getting the two image objects
            GameObject img1 = buffer[0].transform.Find("Image").gameObject;
            GameObject img2 = buffer[1].transform.Find("Image").gameObject;

            //Getting two image objects materials
            Material mat1 = img1.GetComponent<Renderer>().material;
            Material mat2 = img2.GetComponent<Renderer>().material;

            //Checking if the two materials are the same
            if (mat1.name == mat2.name) { //Correct couple

                mat1.color = Color.yellow;
                mat2.color = Color.yellow;
                totcouples--;

                buffer.RemoveAt(1);
                buffer.RemoveAt(0);
            }
            else //Wrong couple
            {
                stop = true;
                Invoke("WrongCouple", 1f);
            }
        }

        //All the couples are turned, termination step
        if (totcouples == 0) {
            GetComponent<TimeBarController>().Completed();
            if (returnToHUB) {
                Trophies.TrophyCompleted("Couples");
                levelLoader.ReturnToHub();
            } else {
                levelLoader.LoadLevelName(nextLevelPath);
            }
        }
    }

    public void InsertInBuffer(GameObject obj) {
        buffer.Add(obj);
    }

    //Assigns materials to objects
    private void InitializeCouples() {
        List<int> indexes = new List<int>();
        int a = 0;
        while (a < materials.Count) {
            indexes.Add(a);
            indexes.Add(a);
            a ++;
        }
        indexes.Shuffle();

        for (int j = 0; j < objects.Count; j ++) {
            GameObject image = objects[j].transform.Find("Image").gameObject;
            image.GetComponent<Renderer>().material = materials[indexes[j]];
        }
    }

    //Makes the movement wait
    private void WrongCouple() {
        GameObject trig1 = buffer[0].transform.Find("Trigger").gameObject;
        trig1.GetComponent<RotationController>().BackRotation();
        GameObject trig2 = buffer[1].transform.Find("Trigger").gameObject;
        trig2.GetComponent<RotationController>().BackRotation();
        buffer.RemoveAt(1);
        buffer.RemoveAt(0);
        stop = false;
    }

}
