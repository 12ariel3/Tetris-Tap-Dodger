using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.BloodyOverlay
{
    [CreateAssetMenu(menuName = "BloodyOverlay/BloodyOverlayConfiguration", fileName = "BloodyOverlayConfiguration")]
    public class BloodyOverlayConfiguration : ScriptableObject
    {
        [SerializeField] private BloodyOverlayMediator[] _BloodyPrefabs;
        private Dictionary<string, BloodyOverlayMediator> _idToBloodyPrefab;

        public BloodyOverlayMediator[] BloodyPrefabs => _BloodyPrefabs;

        private void Awake()
        {
            _idToBloodyPrefab = new Dictionary<string, BloodyOverlayMediator>();
            foreach (var bloodyOverlay in _BloodyPrefabs)
            {
                _idToBloodyPrefab.Add(bloodyOverlay.Id, bloodyOverlay);
            }
        }


        public BloodyOverlayMediator GetProjectileById(string id)
        {
            if (!_idToBloodyPrefab.TryGetValue(id, out var bloody))
            {
                throw new Exception($"BloodyOverlay {id} not found");
            }

            return bloody;
        }
    }
}