namespace Assets.Code.Common.Level
{
    public interface SwordsLevelSystem
    {
        int GetLevel(string swordId);

        void SaveLevel(string swordId, int swordLevel);

        bool GetIfIsSwordUnlocked(string swordId);
        void SaveIfIsSwordUnlocked(string swordId, bool isSwordUnlocked);
    }
}