using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaRand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Se ci sono n totcouples, allora ci sono nx2 totoggetti
        int totcouples = 3;
        int totoggetti = 6;
        int temp = totcouples; //numero totali di numeri da generare
        System.Random randgen = new System.Random();
        List<int> indexes = new List<int>();
        while (temp > 0) {
            //Scelgo un numero randomico tra 0 e (totoggetti - 1)
            int tempnum = randgen.Next(0, (totoggetti-1));
            
            //Controllo se il numero è già stato prelevato
            if (!indexes.Contains(tempnum)) {
                Debug.Log("NUOVO");
                indexes.Add(tempnum);
                temp --;
            }
        }

        Debug.Log("fine estrazione");
        Debug.Log("Indexes contiene elementi; "+indexes.Count);
        for (int i = 0; i < indexes.Count; i ++) {
            Debug.Log("Indice: "+i);
            Debug.Log("Numero: "+indexes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
