using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class ProjectileHittedEventData : EventData
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly int InstanceId;

        public ProjectileHittedEventData(Vector3 position, Quaternion rotation,
                                         int instanceId) : base(EventIds.ProjectileHitted)
        {
            Position = position;
            Rotation = rotation;
            InstanceId = instanceId;
        }
    }
}