using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.AdsData
{
    public class AdsSystemImpl : AdsSystem
    {
        private readonly DataStore _dataStore;
        private const string _adsWereRemoved = "AdsWereRemovedData";


        public AdsSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }



        public bool GetIfIsAdsRemoved()
        {
            var userData = _dataStore.GetData<UserData>(_adsWereRemoved)
                        ?? new UserData();
            return userData.AdsWereRemoved;
        }

        public void SaveIfAdsWereRemoved(bool adsWereRemoved)
        {
            var userData = new UserData { AdsWereRemoved = adsWereRemoved };
            _dataStore.SetData(userData, _adsWereRemoved);
        }
    }
}