using Structs;
using UnityEngine;

namespace UI.UpgradePanel.Cost
{
    public class UpgradeCostShowerController : MonoBehaviour
    {
        [SerializeField] private GameObject costImageAndText;

        [SerializeField] private Transform costParentTransform;


        public void CreateCostImageAndText(CostImage costImage,int cost)
        {
           var obj = Instantiate(costImageAndText, costParentTransform);
           obj.GetComponent<UpgradeCostImageAndText>().SetImageAndTextValue(costImage.Sprite,costImage.Color,cost);
        }
    }
}
