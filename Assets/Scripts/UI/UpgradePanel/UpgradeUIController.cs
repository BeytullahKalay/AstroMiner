using UnityEngine;

namespace UI.UpgradePanel
{
    public class UpgradeUIController : MonoBehaviour
    {
        [SerializeField] private GameObject upgradeProcessImage;
        [SerializeField] private GameObject upgradeButton;
        [SerializeField] private GameObject maxText;

        [SerializeField] private Transform upgradeLevelParentTransform;

        [SerializeField] private int maxUpgradeAmount;

        private int _currentUpgradeAmount;

        public bool IsUpgradeable { get; private set; }

        private void Start()
        {
            IsUpgradeable = true;
            CheckIsUpgradeable();
        }

        public void Upgrade()
        {
            _currentUpgradeAmount++;
            Instantiate(upgradeProcessImage, upgradeLevelParentTransform, true);
            CheckIsUpgradeable();
        }

        private void CheckIsUpgradeable()
        {
            if (_currentUpgradeAmount < maxUpgradeAmount) return;
            
            upgradeButton.SetActive(false);
            maxText.SetActive(true);
            IsUpgradeable = false;
        }
    }
}