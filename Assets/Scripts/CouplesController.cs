using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
NB Bisogna cambiare il codice, aggiungendo una parte che decida in modo randomico come scegliere le coppie
di materiali, e che le assegni in modo casuale ai vari elementi
*/

public class CouplesController : MonoBehaviour
{
    public List<GameObject> objects; //total number of couple elements in the scene
    public List<Material> materials; //materials assigned to the couple elements in "objects"
                                     //materials size can be objects/2
    private List<GameObject> buffer;
    private int totcouples = 0;

    void Start()
    {
        totcouples = objects.Count / 2;
        //InitializeCouples();

        //Assigning CoupleMaterials to objects
        for (int j = 0; j < objects.Capacity; j++) {
            //objects[j].GetComponent<Renderer>().material = materials[j];
            GameObject img = objects[j].transform.Find("Image").gameObject;
            img.GetComponent<Renderer>().material = materials[j];
        }
        buffer = new List<GameObject>();
        
    }

    void Update()
    {
        //When an object in objects is triggered, it inserts itself into buffer
        //When there are two elements into the buffer, they hav to be checked
        if (buffer.Count == 2) {

            //Prelevo i due oggetti immagine
            GameObject img1 = buffer[0].transform.Find("Image").gameObject;
            GameObject img2 = buffer[1].transform.Find("Image").gameObject;

            //Prelevo i materiali dei due oggetti immagine
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

    private void InitializeCouples() {
        //Questo codice deve
        //1) Selezionare in modo randomico i materiali -> modificare la lista di materiali affinchè contenga
        //al proprio interno tutti i possibili materiali assegnabili alle coppie
        /*int temp = totcouples; //numero totali di numeri da generare
        System.Random randgen = new System.Random();
        List<int> indexes = new List<int>();
        while (temp > 0) {
            //Scelgo un numero randomico tra 0 e (totoggetti - 1)
            int tempnum = randgen.Next(0, (totcouples-1));
            
            //Controllo se il numero è già stato prelevato
            if (!indexes.Contains(tempnum)) {
                Debug.Log("Contiene");
                indexes.Add(tempnum);
                temp --;
            }
        }*/

        //2) Assegnare in modo randomico i materiali
        //System.Random randgen = System.Random();
        for (int j = 0; j < objects.Capacity; j++) {



            //objects[j].GetComponent<Renderer>().material = materials[j];
            GameObject img = objects[j].transform.Find("Image").gameObject;
            img.GetComponent<Renderer>().material = materials[j];
        }

    }

}
