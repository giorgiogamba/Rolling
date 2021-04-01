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
    private int totobjects;

    void Start()
    {
        totobjects = objects.Count;
        totcouples = objects.Count / 2;
        buffer = new List<GameObject>();
        InitializeCouples();
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

        //Se ci sono n totcouples, allora ci sono nx2 totoggetti
        int temp = totcouples; //numero totali di numeri da generare
        System.Random randgen = new System.Random();
        List<int> indexes = new List<int>();
        while (temp > 0) {
            //Scelgo un numero randomico tra 0 e (totoggetti - 1)
            int tempnum = randgen.Next(0, (totobjects-1));
            
            //Controllo se il numero è già stato prelevato
            if (!indexes.Contains(tempnum)) {
                indexes.Add(tempnum);
                indexes.Add(tempnum); //Ne aggiungo 2 perchè così ho la coppia
                temp --;
            }
        }

        //2) Assegnare in modo randomico i materiali
        //Prelevo un elemento random dalla lista degli oggetti e vi assegno un materiale
        //nella posizione di esplorazione della lista
        //Segno inoltre l'indice della lista di oggetti utilizzato in una lista di supporto
        //in modo da non riassegnare un materiale alla lista
        List<int> extracted_objs = new List<int>();

        //Controllo che il numero di indici che ho a disposizione e il numero di oggetti
        //Che devo assegnare sia uguale
        Debug.Log("Controllo dimensioni");
        Debug.Log(indexes.Count == totobjects);
        for (int i = 0; i < indexes.Count; i ++) {
            Debug.Log(indexes[i]);
        }

        Debug.Log("Materials ha un numero di materiali pari a "+materials.Count); //2

        //Temp_indexes contiene gli indici estratti finora. Questo devono essere in numero
        //pari al numero di oggetti a cui assegnare il materiale
        int index_index = 0;
        while (extracted_objs.Count <= totobjects) {
            int num = randgen.Next(0, totobjects-1); //numero è in indice che fa riferimento
            //sia alla lista di oggetti che alla lista di indici "indexes"
            /*if (!temp_indexes.Contains(num)) { //Se non ho ancora estratto qesto "num"
                temp_indexes.Add(num);
                int nuovo_indice = indexes[num];
                Debug.Log("Calcolo num, che vale: "+num);
                Debug.Log("Calcolo nuovo_indice, che vale: "+nuovo_indice);
                objects[num].GetComponent<Renderer>().material = materials[nuovo_indice];
            }*/
            if (!extracted_objs.Contains(num)) {
                extracted_objs.Add(num);

                //Assegnamento materiale
                objects[num].GetComponent<Renderer>().material = materials[indexes[index_index]];

                Debug.Log("Ho assegnato il materiale "+num+" con l'indice "+index_index);
                index_index ++;
            }
        }
        Debug.Log("Fine assegnamento");
    }

}
