using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUICarryingPowerController : UpgradeUIController
    {
        protected override void CreateShowerAndText()
        {
            foreach (var carryCost  in upgradeCost.GetCarryUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (carryCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.CreateCostImageAndText(costImage,carryCost.OrbCost);
                    }
                }
            }
        }
    }
}
