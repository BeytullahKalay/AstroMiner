using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class OrbCounterPanel : MonoBehaviour
    {
        [SerializeField] private List<OrbTypeAndText> orbTypeAndTexts = new List<OrbTypeAndText>();

        public static Action<KeyValuePair<OrbType, int>> UpdateText;
        
        private void OnEnable()
        {
            UpdateText += Test;
        }
        
        private void OnDisable()
        {
            UpdateText -= Test;
        }
        
        private void Test(KeyValuePair<OrbType, int> orbType)
        {
            foreach (var orbTypeAndText in orbTypeAndTexts)
            {
                if (orbTypeAndText.Type == orbType.Key)
                {
                    orbTypeAndText.Tmp.text = "X " + orbType.Value;
                }
            }
        }
    }

    [Serializable]
    public struct OrbTypeAndText
    {
        public TMP_Text Tmp;
        public OrbType Type;
    }
}
