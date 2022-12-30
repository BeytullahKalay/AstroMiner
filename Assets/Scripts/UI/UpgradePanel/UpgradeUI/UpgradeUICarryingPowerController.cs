using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUICarryingPowerController : UpgradeUIController
    {
        public override void SetCostImageAndText()
        {
            base.SetCostImageAndText();

            foreach (var carryCost  in upgradeCost.GetCarryUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (carryCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.SetCostImageAndText(costImage,carryCost.OrbCost);
                    }
                }
            }
        }
    }
}
