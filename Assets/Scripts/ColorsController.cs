using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsController : MonoBehaviour
{
    public LevelLoader ll;
    public List<Image> colors; // a ogni esecuzione deve essere inizializzato in maniera random
    public List<GameObject> objs;
    private TimeBarController tbc;
    private int index = 0;
    private int correct = 0;
    private int colors_size = 0;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Image img in colors) {
            GameObject go = objs[i];
            Material mat = go.GetComponent<Renderer>().material;
            mat.color = img.color;
            i++;
        }
        colors_size = colors.Count;
        tbc = GetComponent<TimeBarController>();
        if (tbc == null) {
            Debug.Log("Time Bar Controller è null");
        }
    }

    public void CheckColor(Material mat) {
        if (mat.color == colors[index].color)
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

    // Update is called once per frame
    void Update()
    {
        if (correct == colors_size) {
            tbc.Completed();
            ll.LoadNextLevel();
        }
    }
}