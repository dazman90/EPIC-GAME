using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public GameObject FindClosestObject(string name)
    {
        float distanceToClosestObject = Mathf.Infinity;
        GameObject closestObject = null;
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag(name);

        foreach (GameObject currentObject in allObjects)
        {
            float distanceToObject = (currentObject.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToObject < distanceToClosestObject)
            {
                distanceToClosestObject = distanceToObject;
                closestObject = currentObject;
            }
        }
        Debug.Log(closestObject.name);
        return closestObject;
    }
}
