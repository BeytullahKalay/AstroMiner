using UnityEngine;

[RequireComponent(typeof(CollectActions))]
[RequireComponent(typeof(ICollectInput))]
[RequireComponent(typeof(CollectLineRendererManager))]
[RequireComponent(typeof(CollectCollider))]
[RequireComponent(typeof(SetMoveSpeedOnCollect))]
public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private SelectionImageController selectionImageController;

    private CollectActions _collectActions;

    private ICollectInput _collectInputs;

    private CollectLineRendererManager _collectLineRendererManager;

    private CollectCollider _collectCollider;
    
    private SetMoveSpeedOnCollect _setMoveSpeedOnCollect;

    private void Awake()
    {
        _collectActions = GetComponent<CollectActions>();
        _collectInputs = GetComponent<ICollectInput>();
        _collectCollider = GetComponent<CollectCollider>();
        _collectLineRendererManager = GetComponent<CollectLineRendererManager>();
        _setMoveSpeedOnCollect = GetComponent<SetMoveSpeedOnCollect>();
    }

    private void Update()
    {
        CollectActions(_collectActions.GetFirstCollectibleOrb());
        ReleaseActions(_collectActions.GetFirstCollectedOrb());
        selectionImageController.SetSelectionImagePosition(_collectActions.CollectibleObjects);
    }

    private void CollectActions(Collectible collectible)
    {
        if (collectible == null) return;

        if (Input.GetKeyDown(_collectInputs.ConnectInput))
        {
            collectible.CallConnectedActions(transform, _collectActions);

            // TODO: fix performance issue
            _collectLineRendererManager.CreateConnectedLineRenderer(transform, collectible.GetCollectibleTransform(), collectible);

            // remove collected orb from collectible list
            _collectActions.CollectibleObjects.Remove(collectible);

            // add collected orb to collected list
            _collectActions.CollectedObjects.Add(collectible);

            // check selection image
            _collectActions.CheckSelectionImageOnAmountChanged();
            
            CheckMoveSpeedModification();
        }
    }

    private void ReleaseActions(Collectible collectible)
    {
        if (collectible == null) return;

        if (Input.GetKeyDown(_collectInputs.ReleaseInput))
        {
            // release orb
            collectible.CallReleasedActions();

            // remove line renderer from orb
            _collectLineRendererManager.RemoveLineRenderer(collectible);

            // remove orb from collected orbs
            _collectActions.CollectedObjects.Remove(collectible);

            // if orb still in collectible radius then add orb to collectible list
            if (Vector2.Distance(transform.position, collectible.GetCollectibleTransform().position) < _collectCollider.GetCollectRadius())
            {
                _collectActions.CollectibleObjects.Add(collectible);
                _collectActions.CheckSelectionImageOnAmountChanged();
            }

            CheckMoveSpeedModification();
        }
    }
    
    private void CheckMoveSpeedModification()
    {
        // set move speed if needed
        _setMoveSpeedOnCollect.SetMoveSpeed?.Invoke(_collectActions.CollectedObjects.Count);
    }
}