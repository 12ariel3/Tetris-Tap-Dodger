using Assets.Code.Common.Events;
using Assets.Code.Common.NodesData;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Upgrades
{
    public class UpgradeNode : MonoBehaviour, EventObserver
    {

        [SerializeField] private Button _nodeButton;
        [SerializeField] private Image _nodeWay;
        [SerializeField] private Image _nodeIcon;
        [SerializeField] private Image _nodeIconBackground;
        [SerializeField] private Image _nodeIconDeepBackground;

        [SerializeField] private UpgradeNodeToSpawnConfiguration _nodeToSpawnConfiguration;

        private Color _nodeWayColor;

        private void Awake()
        {
            _nodeWayColor.a = 1;
            _nodeWayColor.r = 0;
            _nodeWayColor.g = 1;
            _nodeWayColor.b = 0;
        }
        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradeNodeActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradeCheckForAvailability, this);
            CheckForAvailabilityAndActivation();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradeNodeActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradeCheckForAvailability, this);
        }

        public void CheckForAvailabilityAndActivation()
        {

            if (ServiceLocator.Instance.GetService<NodesSystem>().GetNodeAvailability(_nodeToSpawnConfiguration.NodeAvailableId))
            {
                _nodeButton.onClick.AddListener(OnNodePressed);
            }
            if (ServiceLocator.Instance.GetService<NodesSystem>().GetNodeActivation(_nodeToSpawnConfiguration.NodeId))
            {
                _nodeButton.interactable = false;
                _nodeWay.color = _nodeWayColor;
            }
        }
        private void OnNodePressed()
        {
            var upgradesPanelEventData = new UpgradesPanelEventData(_nodeToSpawnConfiguration.NodeId, 
                                                    _nodeToSpawnConfiguration.NextNodeAvailableId1,
                                                    _nodeToSpawnConfiguration.NextNodeAvailableId2,
                                                    _nodeToSpawnConfiguration.StatsToAdd, _nodeToSpawnConfiguration.GemCost,
                                                    _nodeIcon, _nodeIconBackground, _nodeIconDeepBackground, GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(upgradesPanelEventData);
        }


        private void ActiveThisNode()
        {
            var nodeSystem = ServiceLocator.Instance.GetService<NodesSystem>();
            nodeSystem.SaveNodeActivation(_nodeToSpawnConfiguration.NodeId, true);
            nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NodeAvailableId, false);

            if (_nodeToSpawnConfiguration.NextNodeAvailableId1 != "None")
            {
                nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NextNodeAvailableId1, true);
            }
            if (_nodeToSpawnConfiguration.NextNodeAvailableId2 != "None")
            {
                nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NextNodeAvailableId2, true);
            }

            _nodeButton.interactable = false;
            _nodeWay.color = _nodeWayColor;

            CheckClassAndSaveStats();
        }

        private void CheckClassAndSaveStats()
        {
            switch (_nodeToSpawnConfiguration.NodeClass)
            {
                case "Hp":
                    var previousHp = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeHp();
                    var newUpgradeHpValue = previousHp + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeHp(newUpgradeHpValue);
                    return;

                case "Fire":
                    var previousCriticalProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeFire();
                    var newUpgradeCriticalProbabilityValue = previousCriticalProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeFire(newUpgradeCriticalProbabilityValue);
                    return;

                case "Poison":
                    var previousCriticalMultiplier = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradePoison();
                    var newUpgradeCriticalMultiplierValue = previousCriticalMultiplier + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradePoison(newUpgradeCriticalMultiplierValue);
                    return;

                case "Ice":
                    var previousExcelentProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeIce();
                    var newUpgradeExcelentProbabilityValue = previousExcelentProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeIce(newUpgradeExcelentProbabilityValue);
                    return;

                case "Water":
                    var previousExcelentMultiplier = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeWater();
                    var newUpgradeExcelentMultiplierValue = previousExcelentMultiplier + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeWater(newUpgradeExcelentMultiplierValue);
                    return;

                case "Electric":
                    var previousHpAbsorbProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeElectric();
                    var newUpgradeHpAbsorbProbabilityValue = previousHpAbsorbProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeElectric(newUpgradeHpAbsorbProbabilityValue);
                    return;

                case "Ghost":
                    var previousHpAbsorbDenominator = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeGhost();
                    var newUpgradeHpAbsorbDenominatorValue = previousHpAbsorbDenominator + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeGhost(newUpgradeHpAbsorbDenominatorValue);
                    return;

                case "Rainbow":
                    var previousMultipleHitsProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeRainbow();
                    var newUpgradeMultipleHitsProbabilityValue = previousMultipleHitsProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeRainbow(newUpgradeMultipleHitsProbabilityValue);
                    return;

                case "Energy":
                    var previousEnergy = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeEnergy();
                    var newUpgradeEnergyValue = previousEnergy + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeEnergy(newUpgradeEnergyValue);

                    var energyNodeActivedEventData = new EnergyNodeActivedEventData(_nodeToSpawnConfiguration.StatsToAdd, GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(energyNodeActivedEventData);
                    return;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.UpgradeNodeActived)
            {
                var upgradeNodeActivedEventData = (UpgradeNodeActivedEventData)eventData;

                if (upgradeNodeActivedEventData.NodeName == _nodeToSpawnConfiguration.NodeId)
                {
                    ActiveThisNode();
                }
            }

            if (eventData.EventId == EventIds.UpgradeCheckForAvailability)
            {
                CheckForAvailabilityAndActivation();
            }
        }
    }
}