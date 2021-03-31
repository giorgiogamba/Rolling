using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    //Parameters
    public Vector3 end_position;
    public GameObject head;
    public float speed;

    private Rigidbody rb;
    private Vector3 start_position;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Prelevo la posizione di partenza
        start_position = transform.position;

        //Calcolo della direzione
        Vector3 direction = end_position - start_position;
            
        //Avvio movimento
        //NB: assunto che il movimento possa avvenire solamente sull'asse x o z, non contemporaneamente
        //NB2: se si modificano sia x che z, allora l'oggetto non si ferma a causa del calcolo della magnitudo
        //Questo è da tenere in conto quando magari si vorrà fare un passaggio in salita che modifica anche y
        if (direction.x > 0) {
            rb.velocity = new Vector3(1 * speed, 0, 0);
        } else if (direction.z > 0) {
            rb.velocity = new Vector3(0, 0, 1 * speed);
        }
    }

    void Update()
    {
        head.transform.position = transform.position;

        //Arrivato al punto end_position, stoppo
        if (Vector3.Distance(end_position, transform.position) <= 0.1) {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
            
    }
}
