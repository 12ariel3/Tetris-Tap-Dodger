namespace Assets.Code.Common.AdsData
{
    public interface AdsSystem
    {
        bool GetIfIsAdsRemoved();

        void SaveIfAdsWereRemoved(bool adsWereRemoved);
    }
}