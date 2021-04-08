using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;

public class ColorsController : MonoBehaviour
{
    public LevelLoader ll;
    public List<Image> canvas;
    public List<Image> colors;
    public List<GameObject> objs; //boxes
    private TimeBarController tbc;
    private int index = 0;
    private int correct = 0;
    private int colors_size = 0;

    void Start()
    {
        Init();
        colors_size = colors.Count;
        tbc = GetComponent<TimeBarController>();
        if (tbc == null) {
            Debug.Log("Time Bar Controller è null");
        }
    }

    //Initializes randomly canvas and objs
    private void Init() {

        //Creating a list of indexes
        int a = 0;
        List<int> indexes = new List<int>();
        while (a < colors.Count) {
            indexes.Add(a);
            a ++;
        }

        indexes.Shuffle(); //shuffling indexes list

        //Assigning colors to canvas
        for (int i = 0; i < canvas.Count; i ++) {
            canvas[i].color = colors[indexes[i]].color;
        }

        //Assigning colors to objs
        indexes.Shuffle();
        for (int i = 0; i < canvas.Count; i ++) {
            objs[i].GetComponent<Renderer>().material.color = colors[indexes[i]].color;
        }

    }

    public void CheckColor(Material mat) {
        if (mat.color == canvas[index].color)
        {
            mat.color = Color.yellow; //changing objs color
            index++; //Updating order index
            correct ++; //updating number of correct colors
        }
        else {
            Debug.Log("SBAGLIATO");
            //implementare l'annullamento delle operazioni nel caso in cui si sbagli ordine
        }
    }

    void Update()
    {
        if (correct == colors_size) {
            tbc.Completed();
            ll.LoadNextLevel();
        }
    }
}