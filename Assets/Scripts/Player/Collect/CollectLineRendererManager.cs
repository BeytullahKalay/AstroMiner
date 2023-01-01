using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;
using UnityEngine.Pool;

namespace Player.Collect
{
    public class CollectLineRendererManager : MonoBehaviour
    {
        [SerializeField] private GameObject collectLineRenderer;

        private readonly Dictionary<Collectible, GameObject> _lineRenderers = new Dictionary<Collectible, GameObject>();

        private ObjectPool<GameObject> _lineRendererObjectPool;

        private void Start()
        {
            InitializeLinerRendererPool();
        }

        private void InitializeLinerRendererPool()
        {
            _lineRendererObjectPool = new ObjectPool<GameObject>(() => { return Instantiate(collectLineRenderer); },
                lineRenderer => { lineRenderer.SetActive(true); }, lineRenderer =>
                {
                    lineRenderer.SetActive(false);
                    lineRenderer.GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
                    lineRenderer.GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);
                }, lineRenderer => { Destroy(lineRenderer); }, true, 10, 20);
        }

        public void CreateConnectedLineRenderer(Transform playerTransform, Transform collectibleTransform, Collectible collectible)
        {
            // get line renderer game object
            var rendererGameObject = _lineRendererObjectPool.Get();

            // TODO: get rid of GetComponent
            // get collect line renderer
            var lineRenderer = rendererGameObject.GetComponent<CollectLineRenderer>();

            // add line renderer object to list
            _lineRenderers.Add(collectible, rendererGameObject);

            // assign line renderer point transforms
            AssignLineRendererPointTransforms(playerTransform, collectibleTransform, lineRenderer);
        }

        private void AssignLineRendererPointTransforms(Transform playerTransform, Transform collectibleTransform,
            CollectLineRenderer lineRenderer)
        {
            lineRenderer.PlayerTransform = playerTransform;
            lineRenderer.CollectibleTransform = collectibleTransform;
        }

        public void RemoveLineRenderer(Collectible collectible)
        {
            _lineRendererObjectPool.Release(_lineRenderers[collectible]);
            _lineRenderers.Remove(collectible);
        }
    }
}