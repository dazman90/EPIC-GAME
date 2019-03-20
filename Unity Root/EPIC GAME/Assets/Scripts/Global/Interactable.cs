using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{

    public float InteractionRadius = 3f;
    SphereCollider radius;
    public bool inRange = false;

    void Start()
    {
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

}
