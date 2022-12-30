using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUIFlySpeedController : UpgradeUIController
    {
        protected override void CreateShowerAndText()
        {
            foreach (var flyCost  in upgradeCost.GetFlyUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (flyCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.CreateCostImageAndText(costImage,flyCost.OrbCost);
                    }
                }
            }
        }
    }
}
