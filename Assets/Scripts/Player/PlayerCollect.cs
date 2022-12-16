using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private CollectibleTriggerActions _collectibleTrigger;

    private ICollectInput _collectInputs;

    private void Awake()
    {
        _collectibleTrigger = GetComponent<CollectibleTriggerActions>();
        _collectInputs = GetComponent<ICollectInput>();
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
        }
        else if (Input.GetKeyDown(_collectInputs.ReleaseInput))
        {
            orb.ReleasedActions?.Invoke();
        }
    }
}