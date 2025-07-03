using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.Player
{
    [CreateAssetMenu(menuName = "Player/PlayersConfiguration", fileName = "PlayersConfiguration")]
    public class PlayersConfiguration : ScriptableObject
    {
        [SerializeField] private PlayerMediator[] _playerPrefabs;
        private Dictionary<string, PlayerMediator> _idToPlayerPrefab;


        private void Awake()
        {
            _idToPlayerPrefab = new Dictionary<string, PlayerMediator>();
            foreach (var player in _playerPrefabs)
            {
                _idToPlayerPrefab.Add(player.Id, player);
            }
        }


        public PlayerMediator GetPlayerById(string id)
        {
            if (!_idToPlayerPrefab.TryGetValue(id, out var player))
            {
                throw new Exception($"Player {id} not found");
            }

            return player;
        }
    }
}