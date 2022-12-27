using System;
using System.Collections.Generic;
using AbstractClasses;
using UI.UpgradePanel;
using UnityEngine;

namespace CollectMachine
{
    
    [RequireComponent(typeof(UpdateCollectedOrbsTexts))]
    public class CollectedOrbCounter : MonoBehaviour
    {
        private readonly Dictionary<Type, int> _counterDictionary = new Dictionary<Type, int>();
        
        private UpdateCollectedOrbsTexts _updateCollectedOrbsTexts;
        
        private void Awake()
        {
            _updateCollectedOrbsTexts = GetComponent<UpdateCollectedOrbsTexts>();
        }
        
        
        public void Collect(Collectible collectible)
        {
            if (!_counterDictionary.ContainsKey(collectible.GetType()))
                _counterDictionary.Add(collectible.GetType(),1);
            else
                _counterDictionary[collectible.GetType()]++;
            
            _updateCollectedOrbsTexts.UpdateTexts(_counterDictionary);
        }

        public Dictionary<Type, int> GetCounterDictionary()
        {
            return _counterDictionary;
        }
    }
}
