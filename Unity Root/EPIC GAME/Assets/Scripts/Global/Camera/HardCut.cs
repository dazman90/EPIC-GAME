using UnityEngine;

public class HardCut : MonoBehaviour
{
    public void Cut(Camera cam,GameObject target, Vector3 offset)
    {

        transform.position = target.transform.position - offset;
        transform.LookAt(target.transform.position);
    }
}
