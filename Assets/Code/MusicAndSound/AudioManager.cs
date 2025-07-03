using Assets.Code.Common.Events;
using Assets.Code.Common.Settings;
using Assets.Code.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.MusicAndSound
{
    public class AudioManager : MonoBehaviour, EventObserver
    {

        [SerializeField] private AudioClipScriptableObject[] _mainMenuMusicSounds;
        [SerializeField] private AudioClipScriptableObject[] _gameMusicSounds;
        [SerializeField] private AudioClipScriptableObject[] _swordSounds;
        [SerializeField] private AudioClipScriptableObject[] _projectileSounds;
        [SerializeField] private AudioClipScriptableObject[] _otherSfxSounds;

        private Dictionary<string, AudioClipScriptableObject> _idToMainMenuMusicSounds;
        private Dictionary<string, AudioClipScriptableObject> _idToGameMusicSounds;
        private Dictionary<string, AudioClipScriptableObject> _idToSwordSounds;
        private Dictionary<string, AudioClipScriptableObject> _idToProjectileSounds;
        private Dictionary<string, AudioClipScriptableObject> _idToOtherSfxSounds;


        [SerializeField] private AudioSource _mainMenuMusicSource;
        [SerializeField] private AudioSource _gameMusicSource;
        [SerializeField] private AudioSource _swordSource;
        [SerializeField] private AudioSource _projectileSource;
        [SerializeField] private AudioSource _otherSfxSource;


        private void Awake()
        {
            CreateAllDictionaries();
        }

        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.VolumeChanged, this);
            SetVolumeIntensity();
        }

        private void SetVolumeIntensity()
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            _mainMenuMusicSource.volume = settingsSystem.GetMainMenuMusicIntensity();
            _gameMusicSource.volume = settingsSystem.GetGameMusicIntensity();
            _swordSource.volume = settingsSystem.GetSwordIntensity();
            _projectileSource.volume = settingsSystem.GetProjectileIntensity();
            _otherSfxSource.volume = settingsSystem.GetUISoundIntensity();

            if (_mainMenuMusicSource.volume < 0.04)
            {
                _mainMenuMusicSource.mute = true;
            }
            else
            {
                _mainMenuMusicSource.mute = false;
            }

            if (_gameMusicSource.volume < 0.04)
            {
                _gameMusicSource.mute = true;
            }
            else
            {
                _gameMusicSource.mute = false;
            }

            if (_swordSource.volume < 0.04)
            {
                _swordSource.enabled = false;
            }
            else
            {
                _swordSource.enabled = true;
            }

            if (_projectileSource.volume < 0.04)
            {
                _projectileSource.enabled = false;
            }
            else
            {
                _projectileSource.enabled = true;
            }

            if (_otherSfxSource.volume < 0.04)
            {
                _otherSfxSource.enabled = false;
            }
            else
            {
                _otherSfxSource.enabled = true;
            }
        }

        private void CreateAllDictionaries()
        {
            _idToMainMenuMusicSounds = new Dictionary<string, AudioClipScriptableObject>();
            foreach (var player in _mainMenuMusicSounds)
            {
                _idToMainMenuMusicSounds.Add(player.AudioName, player);
            }

            _idToGameMusicSounds = new Dictionary<string, AudioClipScriptableObject>();
            foreach (var player in _gameMusicSounds)
            {
                _idToGameMusicSounds.Add(player.AudioName, player);
            }

            _idToSwordSounds = new Dictionary<string, AudioClipScriptableObject>();
            foreach (var player in _swordSounds)
            {
                _idToSwordSounds.Add(player.AudioName, player);
            }

            _idToProjectileSounds = new Dictionary<string, AudioClipScriptableObject>();
            foreach (var player in _projectileSounds)
            {
                _idToProjectileSounds.Add(player.AudioName, player);
            }

            _idToOtherSfxSounds = new Dictionary<string, AudioClipScriptableObject>();
            foreach (var player in _otherSfxSounds)
            {
                _idToOtherSfxSounds.Add(player.AudioName, player);
            }
        }

        public void StopMainMenuMusic()
        {
            _mainMenuMusicSource.Stop();
        }
        public void PlayMainMenuMusic(string name)
        {
            if (_mainMenuMusicSource.enabled == true)
            {
                if (!_idToMainMenuMusicSounds.TryGetValue(name, out AudioClipScriptableObject audio))
                {
                    throw new Exception($"MainMenuMusic {name} not found");
                }

                _mainMenuMusicSource.clip = audio.Audio;
                _mainMenuMusicSource.Play();
            }
        }


        public void StopGameMusic()
        {
            _gameMusicSource.Stop();
        }
        public void PlayGameMusic(string name)
        {
            if (_gameMusicSource.enabled == true)
            {
                if (!_idToGameMusicSounds.TryGetValue(name, out AudioClipScriptableObject audio))
                {
                    throw new Exception($"GameMusic {name} not found");
                }

                _gameMusicSource.clip = audio.Audio;
                _gameMusicSource.Play();
            }
        }

        public void PlaySword(string name)
        {
            if (_swordSource.enabled == true)
            {
                if (!_idToSwordSounds.TryGetValue(name, out AudioClipScriptableObject audio))
                {
                    throw new Exception($"Sword Sound {name} not found");
                }

                _swordSource.clip = audio.Audio;
                _swordSource.Play();
            }
        }

        public void PlayProjectile(string name)
        {
            if (_projectileSource.enabled == true)
            {
                if (!_idToProjectileSounds.TryGetValue(name, out AudioClipScriptableObject audio))
                {
                    throw new Exception($"Projectile Sound {name} not found");
                }

                _projectileSource.PlayOneShot(audio.Audio);
            }
        }

        public void PlayOtherSfx(string name)
        {
            if (_otherSfxSource.enabled == true)
            {
                if (!_idToOtherSfxSounds.TryGetValue(name, out AudioClipScriptableObject audio))
                {
                    throw new Exception($"Other Sfx Sound {name} not found");
                }

                _otherSfxSource.PlayOneShot(audio.Audio);
                _otherSfxSource.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.VolumeChanged)
            {
                SetVolumeIntensity();
            }
        }
    }
}