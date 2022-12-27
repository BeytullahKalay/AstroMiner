using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.UpgradePanel
{
    public class UpdateCollectedOrbsTexts : MonoBehaviour
    {
        public void UpdateTexts(Dictionary<Type, int> dictionary)
        {
            Debug.Log("Called Update Texts");
            
            // foreach (var cost in dictionary)
            // {
            //     //OrbCounterPanel.UpdateText?.Invoke(cost);
            // }
        }
    }
}
