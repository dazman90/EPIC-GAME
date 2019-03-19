using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    public GameObject player;
    FolowPlayer folowplayer;
    public float smoothness;
    public float speed = 1f;
    public GameObject targetObject;
    Quaternion targetRotation;


    public void SetTarget(Camera cam, GameObject target)
    {
        targetObject = target;
        folowplayer = GetComponent<FolowPlayer>();
        //disable player controll
        folowplayer.cameraControllEnabeled = false;
    }

    void Update()
    {
        //calculate destination
        targetRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position);
        //move smoth
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
