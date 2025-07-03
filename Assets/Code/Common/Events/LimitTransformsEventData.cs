using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class LimitTransformsEventData : EventData
    {
        public readonly RectTransform RightLimitTransform;
        public readonly RectTransform LeftLimitTransform;
        public readonly int InstanceId;

        public LimitTransformsEventData(RectTransform rightLimitTransform, RectTransform leftLimitTransform,
                                      int instanceId) : base(EventIds.LimitPositionEventData)
        {
            RightLimitTransform = rightLimitTransform;
            LeftLimitTransform = leftLimitTransform;
            InstanceId = instanceId;
        }
    }
}
