using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;



    void FixedUpdate()
    {
        transform.LookAt(Target.position);
        transform.Translate(Vector3.right * Time.fixedDeltaTime * Speed);
    }
}
