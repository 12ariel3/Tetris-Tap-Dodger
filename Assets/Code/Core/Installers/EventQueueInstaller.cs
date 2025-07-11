﻿using Assets.Code.Common.Events;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class EventQueueInstaller : Installer
    {
        [SerializeField] private EventQueueImpl _eventQueue;
        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_eventQueue.gameObject);
            serviceLocator.RegisterService<EventQueue>(_eventQueue);
        }
    }
}