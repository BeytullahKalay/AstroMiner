using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UpgradePanel.Cost
{
    public class UpgradeCostImageAndText : MonoBehaviour
    {
        [SerializeField] private Image costImage;
        [SerializeField] private TMP_Text costTMPText;

        public void SetImageAndTextValue(Sprite imageSprite,Color imageColor,int cost)
        {
            costImage.sprite = imageSprite;
            costImage.color = imageColor;
            costTMPText.text = "X" + cost.ToString();

        }
    }
}
