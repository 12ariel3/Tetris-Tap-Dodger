using Assets.Code.MusicAndSound;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class AudioInstaller : Installer
    {
        [SerializeField] private AudioManager _audioManager;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_audioManager.gameObject);
            serviceLocator.RegisterService(_audioManager);
        }
    }
}