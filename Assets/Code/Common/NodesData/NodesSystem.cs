namespace Assets.Code.Common.NodesData
{
    public interface NodesSystem
    {
        bool GetNodeActivation(string nodeName);
        void SaveNodeActivation(string nodeName, bool isActived);
        bool GetNodeAvailability(string nodeName);
        void SaveNodeAvailability(string nodeName, bool isActived);
    }
}