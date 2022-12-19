using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectLineRendererManager : MonoBehaviour
{
    [SerializeField] private GameObject collectLineRenderer;

    private readonly Dictionary<Orb, GameObject> _lineRenderers = new Dictionary<Orb, GameObject>();

    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(collectLineRenderer);
            }, lineRenderer =>
            {
                lineRenderer.SetActive(true);
            }, lineRenderer =>
            {
                lineRenderer.SetActive(false);
                lineRenderer.GetComponent<LineRenderer>().SetPosition(0,Vector3.zero);
                lineRenderer.GetComponent<LineRenderer>().SetPosition(1,Vector3.zero);
            }, lineRenderer =>
            {
                Destroy(lineRenderer);
            }, true, 10, 20);
    }

    public void CreateConnectedLineRenderer(Transform playerTransform, Transform orbTransform, Orb orb)
    {
        // get line renderer game object
        var rendererGameObject = _pool.Get();

        // TODO: get rid of GetComponent
        // get collect line renderer
        var lineRenderer = rendererGameObject.GetComponent<CollectLineRenderer>();

        // add line renderer object to list
        _lineRenderers.Add(orb, rendererGameObject);

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
        _pool.Release(_lineRenderers[orb]);
        _lineRenderers.Remove(orb);
    }
}