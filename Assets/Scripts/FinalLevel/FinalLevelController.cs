using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;

public class FinalLevelController : MonoBehaviour
{
    //TODO
    //Questo codice deve tenere traccia del tocco di ogni pedana, e quando tutte le poedane sono state premute deve far comparire la stella
    //Le pedane seguono un ordinamento come quello di colorsController

    public GameObject star;
    public List<GameObject> boxes; //pedane
    public List<GameObject> yellow_canvas;
    public List<Image> canvas; //color canvas
    public List<Image> colors; //images inserted into canvas
    private int index = 0;
    private int correct = 0;

    // Start is called before the first frame update
    void Start()
    {
        star.SetActive(false);
        Init();
        for (int i = 0; i < yellow_canvas.Count; i ++) {
            yellow_canvas[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index < canvas.Count) {
            yellow_canvas[index].SetActive(true);
        }
        
        if (correct == boxes.Count) {
            star.SetActive(true);
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
            boxes[i].GetComponent<Renderer>().material.color = colors[indexes[i]].color;
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
}
