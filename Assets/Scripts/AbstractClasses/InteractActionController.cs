using UnityEngine;

namespace AbstractClasses
{
    public abstract class InteractActionController : MonoBehaviour
    {
        [Header("Interact Action Controller Values")]
        [SerializeField] private GameObject interactImage;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private float checkPlayerRadius = 4f;

        private bool _onInteract;

        public virtual void Start()
        {
            interactImage.SetActive(false);
        }

        private void Update()
        {
            CalculateInteractImageState();
        }

        public virtual void StartInteract()
        {
            _onInteract = true;
        }

        public virtual void StopInteract()
        {
            _onInteract = false;
        }

        private void CalculateInteractImageState()
        {
            if (_onInteract)
            {
                interactImage.SetActive(false);
                return;
            }
        
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
}