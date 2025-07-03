using Assets.Code.Common.TimeMediator;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class TimeInstaller : Installer
    {
        [SerializeField] private TimeMediator _timeMediator;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_timeMediator.gameObject);
            serviceLocator.RegisterService(_timeMediator);
        }
    }
}