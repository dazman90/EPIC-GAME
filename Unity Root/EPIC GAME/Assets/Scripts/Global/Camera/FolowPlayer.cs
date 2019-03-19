using UnityEngine;

public class FolowPlayer : MonoBehaviour
{
    CameraControll cameraControll;
    public Vector3 offset;
    Transform player;
    public bool cameraControllEnabeled = true;

    void Start()
    {
        cameraControll = GetComponent<CameraControll>();
        player = cameraControll.target;
    }

    void LateUpdate()
    {
        if (cameraControllEnabeled)
        {
            transform.position = offset + player.position;
            cameraControll.Controll();
        }
        
        
    }
    
}