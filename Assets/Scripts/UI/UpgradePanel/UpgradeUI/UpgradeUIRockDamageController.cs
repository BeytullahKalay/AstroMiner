using AbstractClasses;

namespace UI.UpgradePanel.UpgradeUI
{
    public class UpgradeUIRockDamageController : UpgradeUIController
    {
        public override void SetCostImageAndText()
        {
            base.SetCostImageAndText();
            
            foreach (var rockDamageCost  in upgradeCost.GetRockDamageUpgradeCosts())
            {
                foreach (var costImage in UISpriteHolder.CostImages)
                {
                    if (rockDamageCost.OrbType == costImage.OrbType)
                    {
                        UpgradeCostShowerController.SetCostImageAndText(costImage,rockDamageCost.OrbCost);
                    }
                }
            }
        }
    }
}
