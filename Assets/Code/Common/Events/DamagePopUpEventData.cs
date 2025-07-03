using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class DamagePopUpEventData : EventData
    {
        public readonly string Id;
        public readonly int AttackValue;
        public readonly Vector3 Position;
        public readonly int InstanceId;

        public DamagePopUpEventData(string id, int attackValue, Vector3 position, int instanceId) : base(EventIds.DamagePopUpValue)
        {
            Id = id;
            AttackValue = attackValue;
            Position = position;
            InstanceId = instanceId;
        }
    }
}