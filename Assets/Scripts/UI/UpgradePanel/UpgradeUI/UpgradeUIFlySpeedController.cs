using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUIFlySpeedController : UpgradeUIController
    {
        public override void SetCostImageAndText()
        {
            base.SetCostImageAndText();

            foreach (var flyCost  in upgradeCost.GetFlyUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (flyCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.SetCostImageAndText(costImage,flyCost.OrbCost);
                    }
                }
            }
        }
    }
}
