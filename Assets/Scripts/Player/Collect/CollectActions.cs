using System.Collections.Generic;
using AbstractClasses;
using UI;
using UnityEngine;

namespace Player.Collect
{
    public class CollectActions : MonoBehaviour
    {
        public List<Collectible> CollectibleObjects = new List<Collectible>();
        public List<Collectible> CollectedObjects = new List<Collectible>();

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
            if (col.TryGetComponent(out Collectible collectibleObject))
            {
                var collectible = col.GetComponent<Collectible>();
    
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
            if (col.TryGetComponent(out Collectible collectibleObject))
            {
                var collectible = col.GetComponent<Collectible>();

                if (collectible.GetIsConnected()) return;

                CollectibleObjects.Add(collectible);
            }
        }
    
        public Collectible GetFirstCollectibleOrb()
        {
            return CollectibleObjects.Count > 0 ? CollectibleObjects[0] : null;
        }

        public Collectible GetFirstCollectedOrb()
        {
            return CollectedObjects.Count > 0 ? CollectedObjects[0] : null;
        }
    }
}