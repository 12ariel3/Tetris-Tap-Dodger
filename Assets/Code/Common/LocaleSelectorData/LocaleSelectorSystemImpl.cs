using Assets.Code.Core.DataStorage;


namespace Assets.Code.Common.LocaleSelectorData
{
    public class LocaleSelectorSystemImpl : LocaleSelectorSystem
    {
        private readonly DataStore _dataStore;
        private const string _localeSelectorData = "LocaleSelectorData";



        public LocaleSelectorSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void SaveLocaleSelector(int localeSelector)
        {
            var userData = new UserData { LocaleSelector = localeSelector };
            _dataStore.SetData(userData, _localeSelectorData);
        }


        public int GetLocaleSelector()
        {
            var userData = _dataStore.GetData<UserData>(_localeSelectorData)
                        ?? new UserData();
            return userData.LocaleSelector;
        }
    }
}
