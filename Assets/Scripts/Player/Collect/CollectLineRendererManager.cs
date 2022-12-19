using System.Collections.Generic;
using UnityEngine;

public class CollectLineRendererManager : MonoBehaviour
{
    [SerializeField] private GameObject collectLineRenderer;
    
    private Dictionary<Orb, GameObject> _lineRenderers = new Dictionary<Orb, GameObject>();

    public void CreateConnectedLineRenderer(Transform playerTransform, Transform orbTransform,Orb orb)
    {
        // create line renderer game object
        var rendererGameObject = Instantiate(collectLineRenderer);

        // TODO: get rid of GetComponent
        // get collect line renderer
        var lineRenderer = rendererGameObject.GetComponent<CollectLineRenderer>();
        
        // add line renderer object to list
        _lineRenderers.Add(orb,rendererGameObject);

        // assign line renderer point transforms
        AssignLineRendererPointTransforms(playerTransform, orbTransform, lineRenderer);
    }

    private void AssignLineRendererPointTransforms(Transform playerTransform, Transform orbTransform,
        CollectLineRenderer lineRenderer)
    {
        lineRenderer.PlayerTransform = playerTransform;
        lineRenderer.CollectedOrbTransform = orbTransform;
    }

    public void RemoveLineRenderer(Orb orb)
    {
        var lineRendererObj = _lineRenderers[orb];
        _lineRenderers.Remove(orb);
        Destroy(lineRendererObj);
    }
    
}
