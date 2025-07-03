using UnityEngine;

namespace Assets.Code.Upgrades
{
    [CreateAssetMenu(menuName = "Player/UpgradeNodeToSpawnConfiguration", fileName = "UpgradeNodeToSpawnConfiguration")]
    public class UpgradeNodeToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private string _nodeClass;
        [SerializeField] private string _nodeId;
        [SerializeField] private string _nodeAvailableId;
        [SerializeField] private bool _hasPercentage;

        [SerializeField] private string _nextNodeAvailableId1;
        [SerializeField] private string _nextNodeAvailableId2;

        [SerializeField] private float _statsToAdd;
        [SerializeField] private int _gemCost;


        public string NodeClass => _nodeClass;
        public string NodeId => _nodeId;
        public string NodeAvailableId => _nodeAvailableId;
        public bool HasPercentage => _hasPercentage;
        public string NextNodeAvailableId1 => _nextNodeAvailableId1;
        public string NextNodeAvailableId2 => _nextNodeAvailableId2;
        public float StatsToAdd => _statsToAdd;
        public int GemCost => _gemCost;
    }
}