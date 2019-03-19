using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    public GameObject player;
    FolowPlayer folowplayer;
    public float smoothness;
    public float speed;
    public GameObject targetObject;
    Quaternion targetRotation;


    public void SetTarget(GameObject target)
    {
        targetObject = target;
        folowplayer = GetComponent<FolowPlayer>();
        //disable player controll
        folowplayer.enabled = false;
        //disable player movement
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    void Update()
    {
        //calculate destination
        targetRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position);
        //move smoth
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
