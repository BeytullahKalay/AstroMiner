using System.Collections.Generic;
using UnityEngine;

public class CollectActions : MonoBehaviour
{
    public List<ICollectible> CollectibleObjects = new List<ICollectible>();
    public List<ICollectible> CollectedObjects = new List<ICollectible>();

    private SelectionImageController _selectionImageController;

    private void Awake()
    {
        _selectionImageController = GetComponent<SelectionImageController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        CheckObjectAndAddToList(col);

        CheckSelectionImageOnAmountChanged();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        CheckObjectAndRemoveFromList(other);
        
        CheckSelectionImageOnAmountChanged();
    }
    
    private void CheckObjectAndRemoveFromList(Collider2D col)
    {
        if (col.TryGetComponent(out ICollectible collectibleObject))
        {
            var collectible = col.GetComponent<ICollectible>();
    
            // if not in range but still connected to player
            if (!CollectibleObjects.Contains(collectible)) return;
    
            CollectibleObjects.Remove(collectible);
        }
    }

    public void CheckSelectionImageOnAmountChanged()
    {
        _selectionImageController.OnListAmountChanged?.Invoke(CollectibleObjects.Count);
    }

    private void CheckObjectAndAddToList(Collider2D col)
    {
        if (col.TryGetComponent(out ICollectible collectibleObject))
        {
            var collectible = col.GetComponent<ICollectible>();

            if (collectible.GetIsConnected()) return;

            CollectibleObjects.Add(collectible);
        }
    }
    
    public ICollectible GetFirstCollectibleOrb()
    {
        return CollectibleObjects.Count > 0 ? CollectibleObjects[0] : null;
    }

    public ICollectible GetFirstCollectedOrb()
    {
        return CollectedObjects.Count > 0 ? CollectedObjects[0] : null;
    }
}