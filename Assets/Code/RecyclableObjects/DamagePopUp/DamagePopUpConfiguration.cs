using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.DamagePopUp
{
    [CreateAssetMenu(menuName = "PopUp/DamagePopUpConfiguration", fileName = "DamagePopUpConfiguration")]
    public class DamagePopUpConfiguration : ScriptableObject
    {
        [SerializeField] private DamagePopUpMediator[] _damagePrefabs;
        private Dictionary<string, DamagePopUpMediator> _idToDamagePrefab;

        public DamagePopUpMediator[] DamagePrefabs => _damagePrefabs;

        private void Awake()
        {
            _idToDamagePrefab = new Dictionary<string, DamagePopUpMediator>();
            foreach (var damage in _damagePrefabs)
            {
                _idToDamagePrefab.Add(damage.Id, damage);
            }
        }


        public DamagePopUpMediator GetProjectileById(string id)
        {
            if (!_idToDamagePrefab.TryGetValue(id, out var damage))
            {
                throw new Exception($"Damage {id} not found");
            }

            return damage;
        }
    }
}