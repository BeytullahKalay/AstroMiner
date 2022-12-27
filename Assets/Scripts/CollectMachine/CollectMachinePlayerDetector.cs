using UnityEngine;

namespace CollectMachine
{
    public class CollectMachinePlayerDetector : MonoBehaviour
    {
        [SerializeField] private Transform triggerTransform;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private float circleRadius = 5f;
        public bool PlayerDetected { get; private set; }

        private void Update()
        {
            if (Physics2D.OverlapCircle(triggerTransform.position,circleRadius,whatIsPlayer))
            {
                PlayerDetected = true;
            }
            else
            {
                PlayerDetected = false;
            }
        }
    

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(triggerTransform.position,circleRadius);
        }

    }
}
