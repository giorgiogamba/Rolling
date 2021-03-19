using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;


    public WheelCollider frontleft;
    public WheelCollider frontright;
    public WheelCollider rearleft;
    public WheelCollider rearright;

    public Transform frontleftT;
    public Transform frontrightT;
    public Transform rearleftT;
    public Transform rearrightT;

    public float motor = 1000;
    public float breakValue = 1000;

    private Vector3 forward;
    private Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        right = Quaternion.Euler(new Vector3(-45, 0, 0)) * forward;
        forward = Quaternion.Euler(new Vector3(45, 0, 0)) * forward;
        
    }

    private void FixedUpdate()
    {
        GetInput();
        /*if (Input.GetKey(KeyCode.W))
        {
            AccelerateUp();
        }
        else if (Input.GetKey(KeyCode.S)) {
            AccelerateDown();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AccelerateLeft();
        } else if (Input.GetKey(KeyCode.D))
        {
            AccelerateRight();
        }*/

        if (Input.GetButtonDown("Up")) {
            AccelerateUp();
        } else if (Input.GetButtonDown("Right"))
        {
            AccelerateRight();
        }

        if (Input.GetButtonUp("Up"))
        {
            Stop();
        } else if (Input.GetButtonUp("Right"))
        {
            Stop();
        }

        //Accelerate();
        //UpdateWheelPoses();
    }

    private void Stop() {
        Debug.Log("Stop");
        frontleft.brakeTorque = breakValue;
        frontright.brakeTorque = breakValue;
        rearleft.brakeTorque = breakValue;
        rearright.brakeTorque = breakValue;
    }

    private void GetInput() {
        horizontalInput = Input.GetAxis("HorizontalKey");
        verticalInput = Input.GetAxis("VerticalKey");
    }

    /*private void Accelerate()
    {
        frontleft.motorTorque = motor * verticalInput;
        frontright.motorTorque = motor * verticalInput;
        rearleft.motorTorque = motor * verticalInput;
        rearright.motorTorque = motor * verticalInput;
    }*/

    private void AccelerateUp()
    {
        frontleft.motorTorque = motor * verticalInput;
        frontright.motorTorque = motor * verticalInput;
        rearleft.motorTorque = motor * verticalInput;
        rearright.motorTorque = motor * verticalInput;
    }

    private void AccelerateDown()
    {

        transform.Rotate(0, 180, 0);

        frontleft.motorTorque = motor * verticalInput;
        frontright.motorTorque = motor * verticalInput;
        rearleft.motorTorque = motor * verticalInput;
        rearright.motorTorque = motor * verticalInput;
    }

    private void AccelerateRight()
    {
        transform.Rotate(0, -90, 0);

        frontleft.motorTorque = motor * horizontalInput;
        frontright.motorTorque = motor * horizontalInput;
        rearleft.motorTorque = motor * horizontalInput;
        rearright.motorTorque = motor * horizontalInput;
    }

    private void AccelerateLeft()
    {
        transform.Rotate(0, 90, 0);

        frontleft.motorTorque = motor * horizontalInput;
        frontright.motorTorque = motor * horizontalInput;
        rearleft.motorTorque = motor * horizontalInput;
        rearright.motorTorque = motor * horizontalInput;
    }

    private void UpdateWheelPoses() {
        UpdateWheelPose(frontleft, frontleftT);
        UpdateWheelPose(frontright, frontrightT);
        UpdateWheelPose(rearleft, rearleftT);
        UpdateWheelPose(rearleft, rearleftT);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform) {
        Vector3 position = transform.position;
        Quaternion quaternion = transform.rotation;

        collider.GetWorldPose(out position, out quaternion);

        transform.position = position;
        transform.rotation = quaternion;
    }
}
