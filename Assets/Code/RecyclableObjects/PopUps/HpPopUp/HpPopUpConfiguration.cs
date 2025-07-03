using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.HpPopUp
{
    [CreateAssetMenu(menuName = "PopUp/HpPopUpConfiguration", fileName = "HpPopUpConfiguration")]
    public class HpPopUpConfiguration : ScriptableObject
    {
        [SerializeField] private HpPopUpMediator[] _hpPrefabs;
        private Dictionary<string, HpPopUpMediator> _idToHpPrefab;

        public HpPopUpMediator[] HpPrefabs => _hpPrefabs;

        private void Awake()
        {
            _idToHpPrefab = new Dictionary<string, HpPopUpMediator>();
            foreach (var value in _hpPrefabs)
            {
                _idToHpPrefab.Add(value.Id, value);
            }
        }


        public HpPopUpMediator GetProjectileById(string id)
        {
            if (!_idToHpPrefab.TryGetValue(id, out var value))
            {
                throw new Exception($"heal or damage {id} not found");
            }

            return value;
        }
    }
}