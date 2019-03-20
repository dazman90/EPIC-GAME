using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(FindClosest))]
public class Interactable : MonoBehaviour
{

    public float InteractionRadius = 3f;
    SphereCollider radius;
    public bool inRange = false;
    bool isInteract = false;
    FindClosest findClosest;
    GameObject player;

    void Start()
    {
        findClosest = GetComponent<FindClosest>();
        radius = GetComponent<SphereCollider>();
        radius.enabled = false;
        radius.isTrigger = true;
        radius.radius = InteractionRadius;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inRange = false;
    }



    public void OnInteractionEntry(GameObject localPlayer)
    {
        isInteract = true;
        player = localPlayer;
        Debug.Log("interaction has occured");
    }

    void OnInteractionExit()
    {
        isInteract = false;
        player = null;
    }
}
