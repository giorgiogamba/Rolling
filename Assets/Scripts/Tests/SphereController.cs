using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveUp()
    {
        float verticalInput = Input.GetAxis("VerticalKey");
        Vector3 direction = new Vector3(0, 0, verticalInput);
        rb.AddForce(direction * speed * Time.deltaTime);

    }

    void MoveRight()
    {
        float horizontalInput = Input.GetAxis("HorizontalKey");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        rb.AddForce(direction * speed * Time.deltaTime);
    }
}
