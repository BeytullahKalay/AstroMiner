using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUIRockDamageController : UpgradeUIController
    {
        protected override void CreateShowerAndText()
        {
            foreach (var rockDamageCost  in upgradeCost.GetRockDamageUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (rockDamageCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.CreateCostImageAndText(costImage,rockDamageCost.OrbCost);
                    }
                }
            }
        }
    }
}
