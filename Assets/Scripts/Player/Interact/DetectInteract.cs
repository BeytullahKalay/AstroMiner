using UnityEngine;

public class DetectInteract : MonoBehaviour
{
    [SerializeField] private float detectPlayerDistance = 2f;
    [SerializeField] private LayerMask whatIsInteractable;

    private Collider2D[] interactable;

    private void Update()
    {
        FindInteractable();
    }

    private void FindInteractable()
    {
        interactable = Physics2D.OverlapCircleAll(transform.position, detectPlayerDistance, whatIsInteractable);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectPlayerDistance);
    }

    public Collider2D[] GetInteractableArray()
    {
        return interactable;
    }
}