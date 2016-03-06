using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
    // Update is called once per frame

    public float speed = .0f;

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    private Quaternion initialRotation;
    private Quaternion gyroInitialRotation;
    public Rigidbody rb;

    public float yRotation = 5.0F;
    private float xRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        gyroInitialRotation = Input.gyro.attitude;

    }

    void Update()
    {

        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);


                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Stationary:
                        if (touch.tapCount == 1)
                        {
                          AccelerateForward(transform);
                        }
                        break;
                    case TouchPhase.Ended:
                        StopMoving(transform);
                        break;
                    case TouchPhase.Canceled:
                        break;
                    default:
                        break;
                }

            }
        }
        else
        {
            StopMoving(transform);
        }




       // MoveSides();
        

       

    }

 

    private void MoveSides()
    {
        Quaternion offsetRotation = Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude;
        transform.localRotation = initialRotation * offsetRotation;
        
        //transform.Rotate(Vector3.right * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime, transform.localPosition.z);
    }

    private void AccelerateForward(Transform myMove)
    {
       myMove.Translate(Input.acceleration.x, 0, -Input.acceleration.z);


        
    }

    private void StopMoving(Transform myMove)
    {
        myMove.Translate(0, 0, 0);
    }

    void OnGUI()
    {

    }
}
