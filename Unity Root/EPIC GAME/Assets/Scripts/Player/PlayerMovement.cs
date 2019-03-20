using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float WalkSpeed;
    public float RunSpeed;
    float CurrentSpeed;
    public Transform Camera;
    public float rotationSpeed = 5f;

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
        /*
        if (Input.GetKeyDown(KeyCode.D))
            transform.Rotate(Vector3.right);
        
        else if (Input.GetKeyDown(KeyCode.A))
            transform.Rotate(Vector3.left);

        if (Input.GetKeyDown(KeyCode.W))
            transform.Rotate(Vector3.forward);

        else if (Input.GetKeyDown(KeyCode.S))
            transform.Rotate(Vector3.back);
        */
        transform.position += (CamR * Input.GetAxisRaw("Horizontal") *Time.deltaTime * CurrentSpeed + (CamF * Input.GetAxisRaw("Vertical")) * Time.deltaTime * CurrentSpeed);
    }

    void FixedUpdate()
    {
        
    }

    public void FaceTarget(Transform target)
    {
        Vector3 direvtion = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }


}
