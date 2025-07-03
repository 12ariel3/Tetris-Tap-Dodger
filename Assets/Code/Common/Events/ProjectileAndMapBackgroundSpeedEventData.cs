

namespace Assets.Code.Common.Events
{
    internal class ProjectileAndMapBackgroundSpeedEventData : EventData
    {
        public readonly float ProjectileAndBackgroundSpeed;
        public readonly int InstanceId;

        public ProjectileAndMapBackgroundSpeedEventData(float projectileAndBackgroundSpeed, int instanceId) 
                                                        : base(EventIds.ProjectileAndBackgroundSpeed)
        {
            ProjectileAndBackgroundSpeed = projectileAndBackgroundSpeed;
            InstanceId = instanceId;
        }
    }
}
