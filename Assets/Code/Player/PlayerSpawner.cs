using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerSpawner : MonoBehaviour, EventObserver
    {

        [SerializeField] private PlayerToSpawnConfiguration _playerConfiguration;
        private PlayerBuilder _playerBuilder;

        private int _swordHp;
        private float _swordFire;
        private float _swordPoison;
        private float _swordIce;
        private float _swordWater;
        private float _swordElectric;
        private float _swordGhost;
        private float _swordRainbow;
        private Sprite _unevolvedSprite;
        private Sprite _evolvedSprite;
        private float _swordLevel;


        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquippedLevelUp, this);
            var playerFactory = ServiceLocator.Instance.GetService<PlayerFactory>();
            _playerBuilder = playerFactory.Create(_playerConfiguration.PlayerId.Value)
                                          .WithLevel()
                                          .WithUpgradesStats()
                                          .WithConfiguration(_playerConfiguration);
        }


        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquippedLevelUp, this);
        }


        public void SpawnUserShip()
        {
            _playerBuilder.WithTrailStats(_swordHp, _swordFire, _swordPoison,
                                          _swordIce, _swordWater, _swordElectric,
                                          _swordGhost, _swordRainbow, _unevolvedSprite, _evolvedSprite, _swordLevel)
                                          .WithLevel()
                                          .WithUpgradesStats();
            _playerBuilder.Build();
        }

        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                _swordHp = swordEquipedEventData._hp;
                _swordFire = swordEquipedEventData._fire;
                _swordPoison = swordEquipedEventData._poison;
                _swordIce = swordEquipedEventData._ice;
                _swordWater = swordEquipedEventData._water;
                _swordElectric = swordEquipedEventData._electric;
                _swordGhost = swordEquipedEventData._ghost;
                _swordRainbow = swordEquipedEventData._rainbow;
                _unevolvedSprite = swordEquipedEventData._swordSpriteUnevolved;
                _evolvedSprite = swordEquipedEventData._swordSpriteEvolved;
                _swordLevel = swordEquipedEventData._level;


                SpawnUserShip();
            }



            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _swordHp = swordEquippedLevelUpEventData.Hp;
                    _swordFire = swordEquippedLevelUpEventData.Fire;
                    _swordPoison = swordEquippedLevelUpEventData.Poison;
                    _swordIce = swordEquippedLevelUpEventData.Ice;
                    _swordWater = swordEquippedLevelUpEventData.Water;
                    _swordElectric = swordEquippedLevelUpEventData.Electric;
                    _swordGhost = swordEquippedLevelUpEventData.Ghost;
                    _swordRainbow = swordEquippedLevelUpEventData.Rainbow;
                }

            }
        }
    }
}