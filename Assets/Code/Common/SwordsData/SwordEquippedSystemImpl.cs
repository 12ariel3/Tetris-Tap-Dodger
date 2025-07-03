using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.SwordsData
{
    public class SwordEquippedSystemImpl : SwordEquippedSystem
    {
        private readonly DataStore _dataStore;
        private const string _swordEquippedData = "AirplaneEquippedData";



        public SwordEquippedSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void SaveSwordEquipped(string swordEquipped)
        {
            var userData = new UserData { SwordEquippedName = swordEquipped };
            _dataStore.SetData(userData, _swordEquippedData);
        }


        public string GetSwordEquipped()
        {
            var userData = _dataStore.GetData<UserData>(_swordEquippedData)
                        ?? new UserData();
            return userData.SwordEquippedName;
        }
    }
}