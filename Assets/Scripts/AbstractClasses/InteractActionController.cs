using Player;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class InteractActionController : MonoBehaviour
    {
        [Header("Interact Action Controller Values")] [SerializeField]
        private GameObject interactImage;
        [SerializeField] private PlayerStateController playerStateController;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private float checkPlayerRadius = 4f;

        private bool _isInteractableImageActive = true;

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
            playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Interact;
            _isInteractableImageActive = false;
        }

        public virtual void StopInteract()
        {
            playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Mining;
            _isInteractableImageActive = true;
        }

        private void CalculateInteractImageState()
        {
            if (!_isInteractableImageActive)
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
            Gizmos.DrawWireSphere(transform.position, checkPlayerRadius);
        }
    }
}