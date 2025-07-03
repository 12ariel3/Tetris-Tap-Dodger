namespace Assets.Code.Common.GemsData
{
    public interface GemsSystem
    {
        void Reset();
        int GetTotalGems();
        public void SaveTotalGems(int totalGems);

        void ShowTotalGems();
        int BattleCurrentGems { get; }
    }
}