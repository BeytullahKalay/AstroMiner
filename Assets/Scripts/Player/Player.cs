using UnityEngine;

[RequireComponent(typeof(SelectionImageController))]
[RequireComponent(typeof(CollectActions))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerRockInteract))]
[RequireComponent(typeof(PlayerCollect))]
[RequireComponent(typeof(CollectActions))]
[RequireComponent(typeof(ICollectInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private SelectionImageController selectionImageController;


    private IMovementInput _movementInput;
    private PlayerMovement _playerMovement;
    private PlayerRenderer _playerRenderer;
    private PlayerRockInteract _playerRockInteract;
    private CollectActions _collectActions;
    private ICollectInput _playerCollectInput;
    private CollectActions _playerCollectActions;

    private void Awake()
    {
        _movementInput = GetComponent<IMovementInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRenderer = GetComponent<PlayerRenderer>();
        _playerRockInteract = GetComponent<PlayerRockInteract>();
        _collectActions = GetComponent<CollectActions>();
    }


    private void Update()
    {
        _playerMovement.MovePlayer(_movementInput.MovementInputVector);
        _playerRenderer.RenderPlayer(_movementInput.MovementInputVector);
        _playerRockInteract.Interact(_movementInput.MovementInputVector);
        selectionImageController.SetSelectionImagePosition(_collectActions.CollectibleOrbs);
    }
}