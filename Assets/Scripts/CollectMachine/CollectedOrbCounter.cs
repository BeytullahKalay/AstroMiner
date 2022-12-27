using System.Collections.Generic;
using AbstractClasses;
using UI.UpgradePanel;
using UnityEngine;

namespace CollectMachine
{
    
    [RequireComponent(typeof(UpdateCollectedOrbsTexts))]
    public class CollectedOrbCounter : MonoBehaviour
    {
        private readonly Dictionary<OrbType, int> _counterDictionary = new Dictionary<OrbType, int>();
        
        private UpdateCollectedOrbsTexts _updateCollectedOrbsTexts;
        
        private void Awake()
        {
            _updateCollectedOrbsTexts = GetComponent<UpdateCollectedOrbsTexts>();
        }
        
        
        public void Collect(Collectible collectible)
        {
            if (!_counterDictionary.ContainsKey(collectible.GetOrbType()))
                _counterDictionary.Add(collectible.GetOrbType(),1);
            else
                _counterDictionary[collectible.GetOrbType()]++;
            
            _updateCollectedOrbsTexts.UpdateTexts(_counterDictionary);
        }

        public Dictionary<OrbType, int> GetCounterDictionary()
        {
            return _counterDictionary;
        }
    }
}
