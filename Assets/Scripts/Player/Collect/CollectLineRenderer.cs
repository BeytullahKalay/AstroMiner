using UnityEngine;

public class CollectLineRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    
    public Transform PlayerTransform;
    public Transform CollectedOrbTransform;

    private void Update()
    {
        lineRenderer.SetPosition(0,PlayerTransform.position);
        lineRenderer.SetPosition(1,CollectedOrbTransform.position);
    }
}
