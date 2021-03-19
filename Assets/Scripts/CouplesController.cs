using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouplesController : MonoBehaviour
{
    public List<GameObject> couples;
    public List<Material> materials;
    private List<GameObject> buffer;
    private int totcouples = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < couples.Capacity; j++) {
            couples[j].GetComponent<Renderer>().material = materials[j];
        }
        buffer = new List<GameObject>();
        totcouples = couples.Count / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //A questo punto bisogna avere un riferimento a due mattonelle che si sono girate
        //buffer che si riempe, a ogni update si verifica se la sua lunghezza è due
        //dopo il controllo si
        if (buffer.Count == 2) {

            //Prelevo i due oggetti immagine
            GameObject img1 = buffer[0].transform.Find("Image").gameObject;
            GameObject img2 = buffer[1].transform.Find("Image").gameObject;

            Material mat1 = img1.GetComponent<Renderer>().material;
            Material mat2 = img2.GetComponent<Renderer>().material;

            //Controllo che i materiali siano uguali
            if (mat1.name == mat2.name) {
                Debug.Log("UGUALI");

                //Se ci sono due coppie uguali, queste si colorano di giallo
                mat1.color = Color.yellow;
                mat2.color = Color.yellow;
                totcouples--;
            }
            else
            {
                //Sbagliati, rigiro
                GameObject trig1 = buffer[0].transform.Find("Trigger").gameObject;
                trig1.GetComponent<RotationController>().BackRotation();
                GameObject trig2 = buffer[1].transform.Find("Trigger").gameObject;
                trig2.GetComponent<RotationController>().BackRotation();
            }

            //Elimnazione dal buffer
            buffer.RemoveAt(1);
            buffer.RemoveAt(0);

            Debug.Log(buffer.Count == 0);

        }

        //se tutte le coppie sono state girate, termino
        if (totcouples == 0) {
            Debug.Log("FINE");
            GetComponent<TimeBarController>().Completed();
        }

        
    }

    public void InsertInBuffer(GameObject obj) {
        buffer.Add(obj);
    }
}
