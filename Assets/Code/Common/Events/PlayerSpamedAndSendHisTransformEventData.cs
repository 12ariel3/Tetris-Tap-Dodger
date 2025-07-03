using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class PlayerSpamedAndSendHisTransformEventData : EventData
    {
        public readonly Transform PlayerTransform;
        public readonly int InstanceId;

        public PlayerSpamedAndSendHisTransformEventData(Transform playerTransform, int instanceId) : base(EventIds.PlayerSpamedAndSendHisTransform)
        {
            PlayerTransform = playerTransform;
            InstanceId = instanceId;
        }
    }
}