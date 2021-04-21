using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Controller : MonoBehaviour
{
 
    public float speed = 10f;
    public float jumpForce = 10f;
    public float jumpOffset = 0.3f;
    public GameObject head;
    public bool canJump = true;
    private Rigidbody rb;
    private float distToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

 
    void FixedUpdate()
    {
        if (InputManagement.IsEnabled()) {
            if (canJump) {
                Jump();
            }
            float horizontal = Input.GetAxis("VerticalKey");
            float vertical = Input.GetAxis("HorizontalKey");

            rb.AddForce(Vector3.forward * speed * vertical);
            rb.AddForce(Vector3.right * speed * horizontal);

            if (vertical == 0 && horizontal == 0) {
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    //In order to make the head stay on tha ball
    void Update() {
        head.transform.position = transform.position;
    }

    void Jump() {
        if (IsGrounded()) //if the character is touching the ground
        {
            if (Input.GetButtonDown("Jump"))
            {
                //rb.AddForce(new Vector3(0f, jumpForce, 0f));
                rb.velocity = Vector3.up * jumpForce;
            }
        }  
    }

    private bool IsGrounded(){
       return Physics.Raycast(transform.position, -Vector3.up, distToGround + jumpOffset);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "OBS") {
            transform.parent.SetParent(other.transform); 
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "OBS") {
            transform.parent.SetParent(null);
        }
    }

}
