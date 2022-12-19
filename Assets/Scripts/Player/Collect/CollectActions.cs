using System.Collections.Generic;
using UnityEngine;

public class CollectActions : MonoBehaviour
{
    public List<Orb> CollectibleOrbs = new List<Orb>();
    public List<Orb> CollectedOrbs = new List<Orb>();

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
            var orb = col.GetComponent<Orb>();
    
            // if not in range but still connected to player
            if (!CollectibleOrbs.Contains(orb)) return;
    
            CollectibleOrbs.Remove(orb);
        }
    }

    public void CheckSelectionImageOnAmountChanged()
    {
        _selectionImageController.OnListAmountChanged?.Invoke(CollectibleOrbs.Count);
    }

    private void CheckObjectAndAddToList(Collider2D col)
    {
        if (col.TryGetComponent(out ICollectible collectibleObject))
        {
            var orb = col.GetComponent<Orb>();

            if (orb.GetIsConnected()) return;

            CollectibleOrbs.Add(orb);
        }
    }
    
    public Orb GetFirstCollectibleOrb()
    {
        return CollectibleOrbs.Count > 0 ? CollectibleOrbs[0] : null;
    }

    public Orb GetFirstCollectedOrb()
    {
        return CollectedOrbs.Count > 0 ? CollectedOrbs[0] : null;
    }
}