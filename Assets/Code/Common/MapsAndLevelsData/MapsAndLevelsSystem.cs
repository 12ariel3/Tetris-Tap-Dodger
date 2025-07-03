namespace Assets.Code.Common.MapsAndLevelsData
{
    public interface MapsAndLevelsSystem
    {
        void SaveMaxMapReached(string maxMapReached);
        string GetMaxMapReached();
        void SaveMaxLevelReached(int maxLevelReached);
        int GetMaxLevelReached();
        void SaveLastMapPlayed(string lastMapPlayed);
        string GetLastMapPlayed();
        void SaveLastLevelPlayed(int lastLevelPlayed);
        int GetLastLevelPlayed();
        void SaveIfIsNewLevelPlayed(bool isNewLevel);
        bool IsNewLevelPlayed();
        void SaveIfIsLastMapLevelPlayed(bool isLastLevel);
        bool IsLastMapLevelPlayed();
        void SaveIfIsFirstUpdate(bool isFirstUpdate);
        bool IsFirstUpdate();
        void SaveIfIsMoonWalkerPassed(bool isMoonWalkerPassed);
        bool IsMoonWalkerPassed();
        void SaveIfIsAtlansAbyssPassed(bool isAtlansAbyssPassed);
        bool IsAtlansAbyssPassed();
        void SaveIfIsVillaSoldatiPassed(bool isVillaSoldatiPassed);
        bool IsVillaSoldatiPassed();
        void SaveIfIsRaklionPassed(bool isRaklionPassed);
        bool IsRaklionPassed();
        void SaveIfIsAcheronPassed(bool isAcheronPassed);
        bool IsAcheronPassed();
        void SaveIfIsGameReviewed(bool isReviewed);
        bool IsGameReviewed();
        void SaveIfIsCongratulationsViewed(bool isViewed);
        bool IsCongratulationsViewed();
    }
}