using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Vector3 forward;
    private Vector3 right;
    private Rigidbody rb;
    private float distToGround;

    //Parameters
    public float speed = 3f;
    public float jumpForce = 3f;

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

        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
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

    void Jump() {
        if (IsGrounded()) //if the character is touching the ground
        {
            Debug.Log("SOno dentro grounded");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Sto premendo JUMP");
                rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            }
        }
        
    }

    private bool IsGrounded(){
       return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
