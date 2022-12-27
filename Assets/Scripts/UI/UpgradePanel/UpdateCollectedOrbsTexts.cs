using System.Collections.Generic;
using UnityEngine;

namespace UI.UpgradePanel
{
    public class UpdateCollectedOrbsTexts : MonoBehaviour
    {
        public void UpdateTexts(Dictionary<OrbType, int> dictionary)
        {
            Debug.Log("Called Update Texts");
            
            foreach (var key in dictionary)
            {
                OrbCounterPanel.UpdateText?.Invoke(key);
            }
        }
    }
}
