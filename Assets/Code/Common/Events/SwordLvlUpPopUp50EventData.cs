using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class SwordLvlUpPopUp50EventData : EventData
    {
        public readonly Vector3 Position;
        public readonly Sprite EvolvedSprite;
        public readonly int InstanceId;

        public SwordLvlUpPopUp50EventData(Vector3 position, Sprite evolvedSprite, int instanceId) : base(EventIds.SwordLevelUp50)
        {
            Position = position;
            EvolvedSprite = evolvedSprite;
            InstanceId = instanceId;
        }
    }
}