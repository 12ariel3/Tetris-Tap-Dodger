namespace Assets.Code.Core.DataStorage
{
    public interface DataStore
    {
        public void SetData<T>(T data, string name);

        public T GetData<T>(string name);
    }
}