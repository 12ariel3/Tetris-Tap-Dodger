using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    [CreateAssetMenu(menuName = "PopUp/UpgradesLevelUpPopUpConfiguration", fileName = "UpgradesLevelUpPopUpConfiguration")]
    public class UpgradesLevelUpPopUpCpnfiguration : ScriptableObject
    {
        [SerializeField] private UpgradesLevelUpPopUpMediator[] _upgradesLevelUpPopUpPrefabs;
        private Dictionary<string, UpgradesLevelUpPopUpMediator> _idToUpgradesLevelUpPopUpPrefab;

        public UpgradesLevelUpPopUpMediator[] UpgradesLevelUpPopUpPrefabs => _upgradesLevelUpPopUpPrefabs;

        private void Awake()
        {
            _idToUpgradesLevelUpPopUpPrefab = new Dictionary<string, UpgradesLevelUpPopUpMediator>();
            foreach (var upgradesLevelUpPopUp in _upgradesLevelUpPopUpPrefabs)
            {
                _idToUpgradesLevelUpPopUpPrefab.Add(upgradesLevelUpPopUp.Id, upgradesLevelUpPopUp);
            }
        }


        public UpgradesLevelUpPopUpMediator GetProjectileById(string id)
        {
            if (!_idToUpgradesLevelUpPopUpPrefab.TryGetValue(id, out var upgradesLevelUpPopUp))
            {
                throw new Exception($"UpgradesLevelUpPopUp {id} not found");
            }

            return upgradesLevelUpPopUp;
        }
    }
}