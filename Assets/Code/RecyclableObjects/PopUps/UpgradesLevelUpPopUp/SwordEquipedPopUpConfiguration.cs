using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    [CreateAssetMenu(menuName = "PopUp/SwordEquipedPopUpConfiguration", fileName = "SwordEquipedPopUpConfiguration")]
    public class SwordEquipedPopUpConfiguration : ScriptableObject
    {
        [SerializeField] private SwordEquipedPopUpMediator[] _swordEquipedPopUpPrefabs;
        private Dictionary<string, SwordEquipedPopUpMediator> _idToSwordEquipedUpPopUpPrefab;

        public SwordEquipedPopUpMediator[] SwordEquipedPopUpPrefabs => _swordEquipedPopUpPrefabs;

        private void Awake()
        {
            _idToSwordEquipedUpPopUpPrefab = new Dictionary<string, SwordEquipedPopUpMediator>();
            foreach (var upgradesLevelUpPopUp in _swordEquipedPopUpPrefabs)
            {
                _idToSwordEquipedUpPopUpPrefab.Add(upgradesLevelUpPopUp.Id, upgradesLevelUpPopUp);
            }
        }


        public SwordEquipedPopUpMediator GetProjectileById(string id)
        {
            if (!_idToSwordEquipedUpPopUpPrefab.TryGetValue(id, out var upgradesLevelUpPopUp))
            {
                throw new Exception($"UpgradesLevelUpPopUp {id} not found");
            }

            return upgradesLevelUpPopUp;
        }
    }
}