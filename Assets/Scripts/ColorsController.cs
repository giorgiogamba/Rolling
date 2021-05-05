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
    public List<GameObject> yellow_canvas;
    public bool returnToHUB;
    public string nextLevelPath;
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
        for (int i = 0; i < yellow_canvas.Count; i ++) {
            yellow_canvas[i].SetActive(false);
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
            //objs[i].GetComponent<Renderer>().material.color = colors[indexes[i]].color;
            objs[i].GetComponent<Renderer>().material.SetColor("_Color", colors[indexes[i]].color);
        }

        Debug.Log("Colors initialized");

    }

    public bool CheckColor(Material mat) {
        if (mat.color == canvas[index].color)
        {
            yellow_canvas[index].SetActive(false);    
            mat.color = Color.yellow; //changing objs color
            index++; //Updating order index
            correct ++; //updating number of correct colors
            return true;
        }
        else {
            Debug.Log("SBAGLIATO");
            return false;
            //implementare l'annullamento delle operazioni nel caso in cui si sbagli ordine
        }
    }

    void Update()
    {
        if (index < canvas.Count) {
            yellow_canvas[index].SetActive(true);
        }
        
        if (correct == colors_size) {
            tbc.Completed();
            if (returnToHUB) {
                Trophies.TrophyCompleted("ColorOrder");
                ll.ReturnToHub();
            } else {
                ll.LoadLevelName(nextLevelPath);
            }
        }
    }
}