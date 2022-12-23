using UnityEngine;

namespace Player.Collect
{
    public class CollectCollider : MonoBehaviour
    {
        [SerializeField] private float collectRadius = 2f;
    
        [SerializeField] private CircleCollider2D selectionCollider;

        private void Awake()
        {
            selectionCollider.radius = collectRadius;
        }

        public float GetCollectRadius()
        {
            return collectRadius;
        }
    }
}
