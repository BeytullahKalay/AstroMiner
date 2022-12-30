using System.Collections.Generic;
using Structs;
using UnityEngine;

namespace UI.UpgradePanel.Cost
{
    public class UpgradeCostShowerController : MonoBehaviour
    {
        [SerializeField] private GameObject costImageAndText;

        [SerializeField] private Transform costParentTransform;
        
        private readonly Dictionary<CostImage, GameObject> _createdUITypeDictionary = new Dictionary<CostImage, GameObject>();

        public void SetCostImageAndText(CostImage costImage, int cost)
        {
            if (!_createdUITypeDictionary.ContainsKey(costImage))
            {
                // if there no created object create
                _createdUITypeDictionary.Add(costImage, Instantiate(costImageAndText, costParentTransform));
                UpdateCostImageAndText(costImage, cost);
            }
            else
            {
                // update created image
                UpdateCostImageAndText(costImage, cost);
            }
        }

        private void UpdateCostImageAndText(CostImage costImage, int cost)
        {
            _createdUITypeDictionary[costImage].GetComponent<UpgradeCostImageAndText>()
                .SetImageAndTextValue(costImage.Sprite, costImage.Color, cost);
        }
    }
}