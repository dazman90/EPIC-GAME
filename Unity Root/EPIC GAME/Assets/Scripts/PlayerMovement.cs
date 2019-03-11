using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float WalkSpeed;
    public float RunSpeed;
    float CurrentSpeed;
    public Transform Camera;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = RunSpeed;
        }
        else
        {
            CurrentSpeed = WalkSpeed;
        }
        Vector3 CamF = Camera.forward;
        Vector3 CamR = Camera.right;
        CamF.y = 0f;
        CamR.y = 0f;
        CamF = CamF.normalized;
        CamR = CamR.normalized;
        transform.position += (CamR * Input.GetAxisRaw("Horizontal") *Time.deltaTime * CurrentSpeed + (CamF * Input.GetAxisRaw("Vertical")) * Time.deltaTime * CurrentSpeed);
    }

    void FixedUpdate()
    {
        
    }


}
