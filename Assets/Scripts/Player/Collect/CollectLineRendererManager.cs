using System.Collections.Generic;
using UnityEngine;

public class CollectLineRendererManager : MonoBehaviour
{
    [SerializeField] private GameObject collectLineRenderer;

    private List<GameObject> _lineRenderers = new List<GameObject>();

    public void CreateConnectedLineRenderer(Transform playerTransform, Transform orbTransform)
    {
        // create line renderer game object
        var rendererGameObject = Instantiate(collectLineRenderer);
        
        
        // TODO: get rid of GetComponent
        // get collect line renderer
        var lineRenderer = rendererGameObject.GetComponent<CollectLineRenderer>();
        
        // add line renderer object to list
        _lineRenderers.Add(rendererGameObject);

        // assing line renderer point transforms
        AssignLineRendererPointTransforms(playerTransform, orbTransform, lineRenderer);
    }

    private void AssignLineRendererPointTransforms(Transform playerTransform, Transform orbTransform,
        CollectLineRenderer lineRenderer)
    {
        lineRenderer.PlayerTransform = playerTransform;
        lineRenderer.CollectedOrbTransform = orbTransform;
    }
    
}
