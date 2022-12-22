using UnityEngine;

public abstract class InteractActionController : MonoBehaviour
{
    [Header("Interact Action Controller Values")]
    [SerializeField] private GameObject interactImage;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private float checkPlayerRadius = 4f;
    


    private void Start()
    {
        interactImage.SetActive(false);
    }



    private void Update()
    {
        CalculateInteractImageState();
    }


    public virtual void StartInteract()
    {
    }

    public virtual void StopInteract()
    {

    }


    private void CalculateInteractImageState()
    {
        if (Physics2D.OverlapCircle(transform.position, checkPlayerRadius, whatIsPlayer))
            SetInteractableImageTo(true);
        else
            SetInteractableImageTo(false);
    }

    private void SetInteractableImageTo(bool state)
    {
        interactImage.SetActive(state);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,checkPlayerRadius);
    }
}