namespace Assets.Code.Common.Score
{
    public interface ScoreSystem
    {
        void Reset();
        int GetTotalScore();
        public void SaveTotalScore(int totalScore);

        void ShowTotalScore();
        int BattleCurrentScore { get; }
    }
}