using UnityEngine;

namespace Player.Collect
{
    public class CollectLineRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        [HideInInspector] public Transform PlayerTransform;
        [HideInInspector] public Transform CollectibleTransform;

        private void Update()
        {
            lineRenderer.SetPosition(0, PlayerTransform.position);
            lineRenderer.SetPosition(1, CollectibleTransform.position);
        }
    }
}