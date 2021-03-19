using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsController : MonoBehaviour
{

    public List<Image> colors; // a ogni esecuzione deve essere inizializzato in maniera random
    public List<GameObject> objs;
    int index = 0;

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
    }

    public void CheckColor(Material mat) {
        if (mat.color == colors[index].color)
        {
            //changing objs color
            mat.color = Color.yellow;

            //Updating order index
            index++;
        }
        else {
            Debug.Log("SBAGLIATO");
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}