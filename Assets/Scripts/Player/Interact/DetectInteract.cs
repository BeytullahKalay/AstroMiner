using UnityEngine;

namespace Player.Interact
{
    public class DetectInteract : MonoBehaviour
    {
        [SerializeField] private float detectPlayerDistance = 2f;
        [SerializeField] private LayerMask whatIsInteractable;

        private Collider2D[] _interactable;

        private void Update()
        {
            FindInteractable();
        }

        private void FindInteractable()
        {
            _interactable = Physics2D.OverlapCircleAll(transform.position, detectPlayerDistance, whatIsInteractable);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, detectPlayerDistance);
        }

        public Collider2D[] GetInteractableArray()
        {
            return _interactable;
        }
    }
}