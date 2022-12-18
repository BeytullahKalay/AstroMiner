using System.Collections.Generic;
using UnityEngine;

public class CollectibleTriggerActions : MonoBehaviour
{
    public readonly List<Orb> CollectibleObjects = new List<Orb>();

    private SelectionImageController _selectionImageController;

    private void Awake()
    {
        _selectionImageController = GetComponent<SelectionImageController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        CheckObjectAndAddToList(col);
        
        _selectionImageController.OnListAmountChanged?.Invoke(CollectibleObjects.Count);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        CheckObjectAndRemoveFromList(other);
        
        _selectionImageController.OnListAmountChanged?.Invoke(CollectibleObjects.Count);
    }

    private void CheckObjectAndAddToList(Collider2D col)
    {
        if (col.TryGetComponent(out ICollectible collectibleObject))
        {
            CollectibleObjects.Add(col.GetComponent<Orb>());
        }
    }

    private void CheckObjectAndRemoveFromList(Collider2D col)
    {
        if (col.TryGetComponent(out ICollectible collectibleObject))
        {
            CollectibleObjects.Remove(col.GetComponent<Orb>());
        }
    }

    public Orb GetFirstOrbTransform()
    {

        if (CollectibleObjects.Count > 0)
        {
            return CollectibleObjects[0];
        }
        else
        {
           return null;
        }
    }

}
