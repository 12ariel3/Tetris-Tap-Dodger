using Assets.Code.Common.AdsData;
using Assets.Code.Common.Command;
using Assets.Code.Common.EnergyData;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Level;
using Assets.Code.Common.LocaleSelectorData;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Common.NodesData;
using Assets.Code.Common.Score;
using Assets.Code.Common.Settings;
using Assets.Code.Common.SwordsData;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core.Serializers;
using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        [SerializeField] private PlayersConfiguration _playersConfiguration;
        protected override void DoStart()
        {
            //PlayerPrefs.DeleteAll();
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
        }

        protected override void DoInstallDependencies()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.RegisterService(CommandQueue.Instance);

            var serializer = new JsonUtilityAdapter();
            var dataStore = new PlayerPrefsDataStoreAdapter(serializer);

            var scoreSystemImpl = new ScoreSystemImpl(dataStore);
            serviceLocator.RegisterService<ScoreSystem>(scoreSystemImpl);



            var gemsSystemImpl = new GemsSystemImpl(dataStore);
            serviceLocator.RegisterService<GemsSystem>(gemsSystemImpl);



            var levelSystemImpl = new LevelSystemImpl(dataStore);
            serviceLocator.RegisterService<LevelSystem>(levelSystemImpl);



            var swordsLevelSystemImpl = new SwordsLevelSystemImpl(dataStore);
            serviceLocator.RegisterService<SwordsLevelSystem>(swordsLevelSystemImpl);



            var swordEquippedSystemImpl = new SwordEquippedSystemImpl(dataStore);
            serviceLocator.RegisterService<SwordEquippedSystem>(swordEquippedSystemImpl);



            var adsSystemImpl = new AdsSystemImpl(dataStore);
            serviceLocator.RegisterService<AdsSystem>(adsSystemImpl);



            var localeSelectorSystemImpl = new LocaleSelectorSystemImpl(dataStore);
            serviceLocator.RegisterService<LocaleSelectorSystem>(localeSelectorSystemImpl);


            InstallPlayerFactory();



            var upgradesSystemImpl = new UpgradesSystemImpl(dataStore);
            serviceLocator.RegisterService<UpgradesSystem>(upgradesSystemImpl);



            var nodesSystemImpl = new NodesSystemImpl(dataStore);
            serviceLocator.RegisterService<NodesSystem>(nodesSystemImpl);



            var energySystemImpl = new EnergySystemImpl(dataStore);
            serviceLocator.RegisterService<EnergySystem>(energySystemImpl);



            var settingsSystemImpl = new SettingsSystemImpl(dataStore);
            serviceLocator.RegisterService<SettingsSystem>(settingsSystemImpl);



            var mapsAndLevelsSystemImpl = new MapsAndLevelsSystemImpl(dataStore);
            serviceLocator.RegisterService<MapsAndLevelsSystem>(mapsAndLevelsSystemImpl);
            serviceLocator.GetService<MapsAndLevelsSystem>().SaveIfIsFirstUpdate(true);
        }

        private void InstallPlayerFactory()
        {
            var playerFactory = new PlayerFactory(Instantiate(_playersConfiguration));
            ServiceLocator.Instance.RegisterService(playerFactory);
        }
    }
}