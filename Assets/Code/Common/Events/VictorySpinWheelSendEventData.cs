namespace Assets.Code.Common.Events
{
    public class VictorySpinWheelSendEventData : EventData
    {
        public readonly int BattleFinalScore;
        public readonly int BattleFinalGems;
        public readonly int InstanceId;
        public VictorySpinWheelSendEventData(int battleFinalScore, int battleFinalGems, int instanceId)
                                            : base(EventIds.VictorySpinWheelSendFinalValues)
        {
            BattleFinalScore = battleFinalScore;
            BattleFinalGems = battleFinalGems;
            InstanceId = instanceId;
        }
    }
}