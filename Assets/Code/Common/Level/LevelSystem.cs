namespace Assets.Code.Common.Level
{
    public interface LevelSystem
    {
        int GetCurrentExp();
        int GetCurrentMaxExp();
        void SaveCurrentMaxExp(int currentMaxExp);
        int GetCurrentLevel();
        void SaveLevelData(int level);

        void SaveCurrentExpData(int currentExp);

        void SetExperienceValues();
    }
}