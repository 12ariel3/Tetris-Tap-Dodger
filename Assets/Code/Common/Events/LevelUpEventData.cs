namespace Assets.Code.Common.Events
{
    public class LevelUpEventData : EventData
    {
        public readonly int Level;

        public LevelUpEventData(int level) : base(EventIds.LevelUp)
        {
            Level = level;
        }
    }
}