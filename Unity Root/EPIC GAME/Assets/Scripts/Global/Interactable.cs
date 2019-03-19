using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float InteractionRadius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractionRadius);
    }
}
