using UnityEngine;

[RequireComponent(typeof(CollectActions))]
[RequireComponent(typeof(ICollectInput))]
[RequireComponent(typeof(CollectLineRendererManager))]
[RequireComponent(typeof(CollectCollider))]
[RequireComponent(typeof(ModifieMoveSpeedOnCollect))]
public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private SelectionImageController selectionImageController;

    private CollectActions _collectActions;

    private ICollectInput _collectInputs;

    private CollectLineRendererManager _collectLineRendererManager;

    private CollectCollider _collectCollider;

    private void Awake()
    {
        _collectActions = GetComponent<CollectActions>();
        _collectInputs = GetComponent<ICollectInput>();
        _collectCollider = GetComponent<CollectCollider>();
        _collectLineRendererManager = GetComponent<CollectLineRendererManager>();
    }

    private void Update()
    {
        CollectActions(_collectActions.GetFirstCollectibleOrb());
        ReleaseActions(_collectActions.GetFirstCollectedOrb());
        selectionImageController.SetSelectionImagePosition(_collectActions.CollectibleOrbs);
    }

    private void CollectActions(Orb orb)
    {
        if (orb == null) return;

        if (Input.GetKeyDown(_collectInputs.ConnectInput))
        {
            orb.CallConnectedActions(transform, _collectActions);

            // TODO: fix performance issue
            _collectLineRendererManager.CreateConnectedLineRenderer(transform, orb.transform, orb);

            // remove collected orb from collectible list
            _collectActions.CollectibleOrbs.Remove(orb);

            // add collected orb to collected list
            _collectActions.CollectedOrbs.Add(orb);

            // check selection image
            _collectActions.CheckSelectionImageOnAmountChanged();
        }
    }

    private void ReleaseActions(Orb orb)
    {
        if (orb == null) return;

        if (Input.GetKeyDown(_collectInputs.ReleaseInput))
        {
            orb.CallReleasedActions();

            _collectLineRendererManager.RemoveLineRenderer(orb);

            _collectActions.CollectedOrbs.Remove(orb);

            if (Vector2.Distance(transform.position, orb.transform.position) < _collectCollider.GetCollectRadius())
            {
                _collectActions.CollectibleOrbs.Add(orb);
                _collectActions.CheckSelectionImageOnAmountChanged();
            }
        }
    }
}