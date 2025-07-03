using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class PlayerInstaller : Installer
    {
        [SerializeField] private PlayerSpawner _playerSpawner;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_playerSpawner.gameObject);
            serviceLocator.RegisterService(_playerSpawner);
        }
    }
}