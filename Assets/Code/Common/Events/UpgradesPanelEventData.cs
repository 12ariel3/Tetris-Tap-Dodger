using UnityEngine.UI;

namespace Assets.Code.Common.Events
{
    public class UpgradesPanelEventData : EventData
    {
        public readonly string NodeId;
        public readonly string NextNodeAvailableId1;
        public readonly string NextNodeAvailableId2;
        public readonly float StatsToAdd;
        public readonly int GemCost;
        public readonly Image NodeIcon;
        public readonly Image NodeBackground;
        public readonly Image NodeDeepBackground;
        public readonly int InstanceId;

        public UpgradesPanelEventData(string nodeId, string nextNodeAvailableId1, string nextNodeAvailableId2, float statsToAdd, int gemCost,
                                      Image nodeIcon, Image nodeBackground, Image nodeDeepBackground,
                                      int instanceId) : base(EventIds.UpgradesPanelView)
        {
            NodeId = nodeId;
            NextNodeAvailableId1 = nextNodeAvailableId1;
            NextNodeAvailableId2 = nextNodeAvailableId2;
            StatsToAdd = statsToAdd;
            GemCost = gemCost;
            NodeIcon = nodeIcon;
            NodeBackground = nodeBackground;
            NodeDeepBackground = nodeDeepBackground;
            InstanceId = instanceId;
        }
    }
}