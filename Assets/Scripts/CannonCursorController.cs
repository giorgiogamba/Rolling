using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCursorController : MonoBehaviour
{
    private Vector3 forward;
    private Vector3 right;

    //Parameters
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Imposto il forward come direzione verticale "reale"
        Vector3 temp = Camera.main.transform.forward;
        forward = Quaternion.Euler(new Vector3(45, 0, 0)) * temp;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        //Ruoto la direzione destra di 90 gradi rispetto alla verticale
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            MoveUp();
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ) {
            MoveRight();
        }
    }

    void MoveUp() {
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(upMovement);

        //Rotazione
        transform.forward = heading;

        //Movimento
        transform.position += upMovement;
    }

    void MoveRight()
    {
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 heading = Vector3.Normalize(rightMovement);

        //Rotazione
        transform.forward = heading;

        //Movimento
        transform.position += rightMovement;
    }
}
