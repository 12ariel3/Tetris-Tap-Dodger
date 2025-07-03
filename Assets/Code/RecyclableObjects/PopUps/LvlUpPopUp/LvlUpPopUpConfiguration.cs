using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp
{
    [CreateAssetMenu(menuName = "PopUp/LvlUpPopUpConfiguration", fileName = "LvlUpPopUpConfiguration")]
    public class LvlUpPopUpConfiguration : ScriptableObject
    {
        [SerializeField] private LvlUpPopUpMediator[] _lvlUpPrefabs;
        private Dictionary<string, LvlUpPopUpMediator> _idToLvlUpPrefab;

        public LvlUpPopUpMediator[] LvlUpPrefabs => _lvlUpPrefabs;

        private void Awake()
        {
            _idToLvlUpPrefab = new Dictionary<string, LvlUpPopUpMediator>();
            foreach (var value in _lvlUpPrefabs)
            {
                _idToLvlUpPrefab.Add(value.Id, value);
            }
        }


        public LvlUpPopUpMediator GetProjectileById(string id)
        {
            if (!_idToLvlUpPrefab.TryGetValue(id, out var value))
            {
                throw new Exception($"Lvl up pop up {id} not found");
            }

            return value;
        }
    }
}