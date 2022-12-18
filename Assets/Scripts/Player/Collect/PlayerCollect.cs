using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private CollectibleTriggerActions _collectibleTrigger;

    private ICollectInput _collectInputs;

    private CollectLineRendererManager _collectLineRendererManager;

    private void Awake()
    {
        _collectibleTrigger = GetComponent<CollectibleTriggerActions>();
        _collectInputs = GetComponent<ICollectInput>();
        _collectLineRendererManager = GetComponent<CollectLineRendererManager>();
    }
    
    private void Update()
    {
        CollectAndReleaseActions(_collectibleTrigger.GetFirstOrbTransform());
    }

    private void CollectAndReleaseActions(Orb orb)
    {
        if (orb == null) return;

        if (Input.GetKeyDown(_collectInputs.ConnectInput))
        {
            orb.ConnectedActions?.Invoke(transform);
            _collectLineRendererManager.CreateConnectedLineRenderer(transform,orb.transform);
        }
        else if (Input.GetKeyDown(_collectInputs.ReleaseInput))
        {
            orb.ReleasedActions?.Invoke();
            // TODO: add remove line renderer function
        }
    }
}