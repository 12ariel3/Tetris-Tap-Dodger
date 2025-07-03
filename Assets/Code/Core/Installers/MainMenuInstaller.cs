using Assets.Code.Common.EnergyData;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Level;
using Assets.Code.Common.Score;
using Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp;
using Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp;
using Assets.Code.UI;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class MainMenuInstaller : GeneralInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GemsView _gemsView;
        [SerializeField] private LevelExperienceView _levelExperienceView;
        [SerializeField] private EnergyView _energyView;
        [SerializeField] private UpgradesLevelUpPopUpSpawner _upgradesLevelUpPopUpSpawner;
        [SerializeField] private LvlUpPopUpSpawner _lvlUpPopUpSpawner;
        [SerializeField] private UpgradesLevelUpPopUpCpnfiguration _upgradesLevelUpPopUpConfiguration;
        [SerializeField] private SwordEquipedPopUpConfiguration _swordEquipedPopUpConfiguration;
        [SerializeField] private LvlUpPopUpConfiguration _lvlUpPopUpConfiguration;



        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<LevelSystem>().SetExperienceValues();
            ServiceLocator.Instance.GetService<EnergySystem>().SetEnergyValues();
            ServiceLocator.Instance.GetService<ScoreSystem>().ShowTotalScore();
            ServiceLocator.Instance.GetService<GemsSystem>().ShowTotalGems();
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(_scoreView);
            ServiceLocator.Instance.RegisterService(_gemsView);
            ServiceLocator.Instance.RegisterService(_levelExperienceView);
            ServiceLocator.Instance.RegisterService(_energyView);
            ServiceLocator.Instance.RegisterService(_upgradesLevelUpPopUpSpawner);
            ServiceLocator.Instance.RegisterService(_lvlUpPopUpSpawner);

            InstallUpgradesLevelUpPopUpFactory();
            InstallSwordEquipedPopUpFactory();
            InstallLvlUpPopUpConfiguration();
        }

        private void InstallUpgradesLevelUpPopUpFactory()
        {
            var upgradesLevelUpPopUpFactory = new UpgradesLevelUpPopUpFactory(Instantiate(_upgradesLevelUpPopUpConfiguration));
            ServiceLocator.Instance.RegisterService(upgradesLevelUpPopUpFactory);
        }

        private void InstallSwordEquipedPopUpFactory()
        {
            var swordEquipedPopUpFactory = new SwordEquipedPopUpFactory(Instantiate(_swordEquipedPopUpConfiguration));
            ServiceLocator.Instance.RegisterService(swordEquipedPopUpFactory);
        }

        private void InstallLvlUpPopUpConfiguration()
        {
            var LvlUpPopUpFactory = new LvlUpPopUpFactory(Instantiate(_lvlUpPopUpConfiguration));
            ServiceLocator.Instance.RegisterService(LvlUpPopUpFactory);
        }


        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<ScoreView>();
            ServiceLocator.Instance.UnregisterService<GemsView>();
            ServiceLocator.Instance.UnregisterService<LevelExperienceView>();
            ServiceLocator.Instance.UnregisterService<EnergyView>();
            ServiceLocator.Instance.UnregisterService<UpgradesLevelUpPopUpSpawner>();
            ServiceLocator.Instance.UnregisterService<UpgradesLevelUpPopUpFactory>();
            ServiceLocator.Instance.UnregisterService<SwordEquipedPopUpFactory>();
            ServiceLocator.Instance.UnregisterService<LvlUpPopUpSpawner>();
            ServiceLocator.Instance.UnregisterService<LvlUpPopUpFactory>();
        }
    }
}