using System;
using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;

namespace Player.Collect.CollectMachine
{
    public class CollectedOrbCounter : MonoBehaviour
    {
        private readonly Dictionary<Type, int> _counterDictionary = new Dictionary<Type, int>();
        
        public void Collect(Collectible collectible)
        {
            if (!_counterDictionary.ContainsKey(collectible.GetType()))
            {
                _counterDictionary.Add(collectible.GetType(),1);
            }
            else
            {
                _counterDictionary[collectible.GetType()]++;
            }
        }

        public Dictionary<Type, int> GetCounterDictionary()
        {
            return _counterDictionary;
        }
    }
}
