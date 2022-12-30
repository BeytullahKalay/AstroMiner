using SCOB.UISpriteDecider;
using UI.UpgradePanel.Cost;
using UnityEngine;

namespace AbstractClasses
{
    
    [RequireComponent(typeof(UpgradeCostShowerController))]
    public abstract class UpgradeUIController : MonoBehaviour
    {
        [SerializeField] protected UpgradeCostController upgradeCost;
        
        [SerializeField] private GameObject upgradeProcessImage;
        [SerializeField] private GameObject upgradeButton;
        [SerializeField] private GameObject maxText;

        [SerializeField] private Transform upgradeLevelParentTransform;
        [SerializeField] private Transform costTransform;

        [SerializeField] private int maxUpgradeAmount;
        
        public bool IsUpgradeable { get; private set; }
        
        protected UISpriteHolder UISpriteHolder;

        protected UpgradeCostShowerController UpgradeCostShowerController;
        
        private int _currentUpgradeAmount;

        private void Awake()
        {
            UpgradeCostShowerController = GetComponent<UpgradeCostShowerController>();
            UISpriteHolder = GameManager.Instance.GetUISpriteHolder();
        }

        public virtual void Start()
        {
            SetCostImageAndText();
            InitializeUpgradeable();
        }

        private void InitializeUpgradeable()
        {
            IsUpgradeable = true;
            CheckIsUpgradeable();
        }

        public void OnUpgrade()
        {
            // increase current upgrade amount
            _currentUpgradeAmount++;
            
            // create new process image in selected grid layout group which can visualize upgrade amount
            Instantiate(upgradeProcessImage, upgradeLevelParentTransform, true);
            
            // check is upgradable
            CheckIsUpgradeable();
        }

        private void CheckIsUpgradeable()
        {
            if (_currentUpgradeAmount < maxUpgradeAmount) return;
            
            upgradeButton.SetActive(false);
            maxText.SetActive(true);
            IsUpgradeable = false;
            costTransform.gameObject.SetActive(false);
        }

        public virtual void SetCostImageAndText()
        {
            if(!IsUpgradeable) return;
        }
    }
}